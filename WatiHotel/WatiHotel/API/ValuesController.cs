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
        [Route("test/GetObject")]
        [HttpGet]
        public Data Get()
        {
            Data mesData = new Data();
            List<Destination> destinations = new List<Destination>();
            List<Hotel> hotels = new List<Hotel>();
            ArrayList Reservations = new ArrayList();

            Destination uneDestinationA = new Destination();
            uneDestinationA.City = "LosAngeles";
            uneDestinationA.Country = "USA";
            uneDestinationA.Id = 1;

            Hotel unHotelA = new Hotel();
            unHotelA.Id = 1;
            unHotelA.Name = "Foruml1";
            unHotelA.Price = 40.00;
            unHotelA.Room_available = 10;
            unHotelA.Room_max = 12;
            unHotelA.Address = "425 Evergreen Terasse";
            unHotelA.Destination = 1;

            hotels.Add(unHotelA);
            hotels.Add(unHotelA);
            destinations.Add(uneDestinationA);
            mesData.Hotels = hotels;
            mesData.Destinations = destinations;

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