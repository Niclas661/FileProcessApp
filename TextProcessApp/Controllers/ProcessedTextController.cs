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

namespace TextProcessApp.Controllers
{
    [RoutePrefix("api/textformat")]
    public class ProcessedTextController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// TODO: fix file extension
        /*[System.Web.Http.AcceptVerbs("GET")]
        [System.Web.Http.HttpGet]
        [Route("processedtext/{fileExtension}/{pathFile}")]
        public IHttpActionResult Get([FromBody]string fileExtension,[FromBody]string pathFile)
        {
            /*
            string content = null;

            string rootPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string localPath = new Uri(rootPath).LocalPath;
            FileStream file = new FileStream(Path.Combine(localPath, @"..\Data\", pathFile + "." + fileExtension), FileMode.Open, FileAccess.Read);
            
            StreamReader sr = new StreamReader(file);
            content = sr.ReadToEnd();
            ProcessedText resultObj = new ProcessedText(content);
            var json = new JavaScriptSerializer().Serialize(resultObj);
            
            return Ok(resultObj);
            

            return Ok();
        }*/
        
        [Route("{fileExtension}/{pathFile}")]
        [HttpGet]
        public IHttpActionResult Get(string fileExtension, string pathFile)
        {
            string content = null;
            try
            {
                string rootPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                string localPath = new Uri(rootPath).LocalPath;
                if (fileExtension.ToLower() == "rtf")
                {
                    RTFFormatter rtfF = new RTFFormatter();
                    content = rtfF.ReturnRTFContent(Path.Combine(localPath, @"..\Data\", pathFile + "." + fileExtension));
                }
                else
                {
                    FileStream file = new FileStream(Path.Combine(localPath, @"..\Data\", pathFile + "." + fileExtension), FileMode.Open, FileAccess.Read);
                    using (StreamReader sr = new StreamReader(file))
                    {
                        content = sr.ReadToEnd();
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
