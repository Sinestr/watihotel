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
        [Route("watiHotel")]
        [HttpGet]
        public Data GetAllData()
        {
            Data mesData = new Data();
            return mesData;
        }

        [Route("watiHotel/hotels")]
        [HttpGet]
        public List<Hotel> GetAllHotel()
        {
            Data mesData = new Data();
            return mesData.Hotels;
        }

        [Route("watiHotel/reservations")]
        [HttpGet]
        public List<Reservation> GetAllReservations()
        {
            Data mesData = new Data();
            return mesData.Reservations;
        }

        [Route("watiHotel/Destination")]
        [HttpGet]
        public List<Destination> GetAllDestinations()
        {
            Data mesData = new Data();
            return mesData.Destinations;
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