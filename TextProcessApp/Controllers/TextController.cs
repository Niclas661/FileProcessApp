using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TextProcessApp.Controllers
{
    public class TextController : ApiController
    {
        public Object Get(string text)
        {
            Dictionary<string, string> myDict = new Dictionary<string, string>();
            myDict.Add("Hello", "Bye");
            return Json(myDict);
        }
    }
}
