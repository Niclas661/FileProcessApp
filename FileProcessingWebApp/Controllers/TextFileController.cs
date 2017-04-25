using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FileProcessingWebApp.Controllers
{
    public class TextFileController : ApiController
    {
        // GET: api/TextFile
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TextFile/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TextFile
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TextFile/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TextFile/5
        public void Delete(int id)
        {
        }
    }
}
