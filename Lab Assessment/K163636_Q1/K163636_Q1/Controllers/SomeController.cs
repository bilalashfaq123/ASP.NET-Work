using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace K163636_Q1.Controllers
{
    public class SomeController : ApiController
    {
        // GET: Some

        public string Get()
        {
            return "No parameter Passed";
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value = " +id;
        }
        [System.Web.Http.HttpGet]
        public string MyAction()
        {

            return "your personalized Action";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }


        // DELETE api/values/5
        public void Delete(int id)
        {
        }


    }
}