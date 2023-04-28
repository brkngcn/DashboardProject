using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Dashboard.Controllers
{
     
    public class ValuesController : ApiController
    {
        public static string valueApi = "Empty";
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { valueApi, "value2" };
        }

        // GET api/values/5
        public string Get(string id)
        {
            valueApi = id.ToString();
            return "New Value 1 :"+valueApi;
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        
        public string sendcall(string id)
        {
            valueApi = id.ToString();
            return "New Value send :" + valueApi;
        }

    }
}
