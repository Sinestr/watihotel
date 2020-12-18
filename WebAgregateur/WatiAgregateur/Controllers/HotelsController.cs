using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using WatiAgregateur.Models.Hotel;

namespace WatiAgregateur.Controllers
{
    [Route("watiAgrega/Hotels")]
    public class HotelsController : ApiController
    {
        public const string BEARER_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MSwiaWF0IjoxNjA4MjQ1NzE1LCJleHAiOjE2MDgzMzIxMTV9.F19s1WvM_h_k6JsVBTUnCzqwUnvqQ7noVRLbu1ku7Ew";
        public const string API_SIMBENJ_URL = "https://mysterious-eyrie-25660.herokuapp.com/reservations";
        public ApiAgregHotelData AgregHotelData = new ApiAgregHotelData();

        #region GET
        [Route("getAllHotelsData")]
        [HttpGet]
        public ApiAgregHotelData GetAllCarData()
        {
            AgregHotelData.Hotels = this.GetHotels();

            return AgregHotelData;
        }

        [Route("getHotels")]
        [HttpGet]
        public List<Hotel> GetHotels()
        {
            List<Hotel> agregHotels = new List<Hotel>();

            //Création de la requête pour récupérer les voitures en location
            //API Simon Benjamin
            WebRequest req = HttpWebRequest.Create("http://watihotelapi.azurewebsites.net/watiHotel/hotels");
            req.Method = "GET";
            req.ContentType = "application/json";
            //Appel de la requête
            HttpWebResponse myHttpWebResponse2 = (HttpWebResponse)req.GetResponse();
            var repStream2 = myHttpWebResponse2.GetResponseStream();
            var reader2 = new StreamReader(repStream2);
            
            List<WatiAgregateur.Models.Hotel.ApiAdamTangi.Hotel> hotels = 
                JsonConvert.DeserializeObject<List<WatiAgregateur.Models.Hotel.ApiAdamTangi.Hotel>>(reader2.ReadToEnd());

            foreach (WatiAgregateur.Models.Hotel.ApiAdamTangi.Hotel item in hotels)
            {
                agregHotels.Add(new Hotel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address,
                    Descritpion = item.Descritpion,
                    Destination = item.Destination,
                    Disponibilites = item.Disponibilites,
                    Price = item.Price,
                    RoomMax = item.RoomMax

                });
            }

            return agregHotels;
        }
        #endregion
    }
}