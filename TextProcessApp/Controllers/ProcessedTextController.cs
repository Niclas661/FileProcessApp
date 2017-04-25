using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TextProcessApp.Models;
using System.Web.Script.Serialization;

namespace TextProcessApp.Controllers
{
    public class ProcessedTextController : ApiController
    {
        ProcessedText text = new ProcessedText("This is a \"quick\" test. This will go fine. A man with a gun is a man with no honor.");
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// THIS METHOD HAS TO WORK IN THE FOLLOWING:
        /// READ ID PARAMETER
        /// GET FROM SQL DATABASE THAT ID
        /// CREATE PROCESSEDTEXT OBJECT
        /// GET LOCAL TEXT FILE FROM PATH REFERENCE
        /// CONVERT OBJECT TO JSON
        /// RETURN JSON
        public IHttpActionResult GetProcessedText(int id)
        {
            var json = new JavaScriptSerializer().Serialize(text);
            
            return Ok(text);
            
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
        [HttpPost]
        public IHttpActionResult PostText(string text)
        {
            return Ok(text);
        }
    }
}
