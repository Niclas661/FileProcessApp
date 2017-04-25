using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TextProcessApp.Models;

namespace TextProcessApp.Controllers
{
    public class ProcessedTextController : ApiController
    {
        ProcessedText text = new ProcessedText("This is a \"quick\" test. This will go fine. A man with a gun is a man with no honor.");
        //this has to work
        public IHttpActionResult GetProcessedText(string text)
        {
            ProcessedText pcT = new ProcessedText(text);
            1
            var result = pcT;

            return Ok(result);
        }
    }
}
