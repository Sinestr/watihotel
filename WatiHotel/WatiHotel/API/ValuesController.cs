using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatiHotel.Models;
using WebService.WatiHotel;

namespace WatiHotel.API
{
    [Route("test")]
    public class ValuesController : ApiController
    {
        // GET api/<controller>
        

        // GET api/<controller>/5
        [Route("data")]
        [HttpGet]
        public Data GetAllData()
        {
            Data mesData = new Data();
            return mesData;
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}