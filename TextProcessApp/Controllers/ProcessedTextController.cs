using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TextProcessApp.Models;
using System.Web.Script.Serialization;
using System.Web.UI.HtmlControls;
using System.Web;
using System.IO;
using TextProcessApp.Helpers;
using System.Text.RegularExpressions;

namespace TextProcessApp.Controllers
{
    [RoutePrefix("api/textformat")]
    public class ProcessedTextController : ApiController
    {        
        [Route("{fileExtension}/{pathFile}")]
        [HttpGet]
        public IHttpActionResult Get(string fileExtension, string pathFile)
        {
            string content = null;
            try
            {
                string rootPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                string localPath = new Uri(rootPath).LocalPath;
                //is the file an rtf?
                if (fileExtension.ToLower() == "rtf")
                {
                    RTFFormatter rtfF = new RTFFormatter();
                    content = rtfF.ReturnFormattedContent(Path.Combine(localPath, @"..\Data\", pathFile + "." + fileExtension));
                }
                else
                {
                    FileStream file = new FileStream(Path.Combine(localPath, @"..\Data\", pathFile + "." + fileExtension), FileMode.Open, FileAccess.Read);
                    using (StreamReader sr = new StreamReader(file))
                    {
                        content = sr.ReadToEnd();
                        content = Regex.Replace(content, "[\n\f]", " ");
                    }
                }

                
                ProcessedText resultObj = new ProcessedText(content);
                //var json = new JavaScriptSerializer().Serialize(resultObj);

                return Ok(resultObj);
            }
            catch(Exception e)
            {
                return InternalServerError(e);
            }

            //return Ok(resultObj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        /// THIS METHOD HAS TO WORK IN THE FOLLOWING:
        /// GENERATE UNIQUE ID FOR TEXT FILE
        /// SAVE TEXT FILE LOCALLY
        /// ADD TEXT FILE REFERENCE TO SQL DATABASE ALONG WITH UNIQUE ID
        /// 

        /*
        [HttpPost]
        public HttpResponseMessage Post(HtmlInputFile inputFile)
        {
            if (inputFile.PostedFile != null)
            {
                string path = "data/";
                HttpPostedFile file = inputFile.PostedFile;
                string savePath = Path.Combine(path, Path.GetFileName(file.FileName));
                file.SaveAs(path + file.FileName);

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
            /*
            if (text != null)
            {

                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotAcceptable);
            }
        }*/
    }
}
