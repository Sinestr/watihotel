using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using WatiAgregateur.Models;
using WatiAgregateur.Models.Voiture;
using WatiAgregateur.Models.Voiture.ApiSimonBenjamin;
using WatiAgregateur.Models.Voiture.ApiYannigJeremy;
using Reservation = WatiAgregateur.Models.Voiture.Reservation;

namespace WatiAgregateur.Controllers
{
    [Route("watiAgrega/Voitures")]
    public class VoituresController: ApiController
    {
        public const string BEARER_TOKEN = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MSwiaWF0IjoxNjA4MjQ1NzE1LCJleHAiOjE2MDgzMzIxMTV9.F19s1WvM_h_k6JsVBTUnCzqwUnvqQ7noVRLbu1ku7Ew";
        public const string API_SIMBENJ_URL = "https://mysterious-eyrie-25660.herokuapp.com/reservations";
        public ApiCarData AgregCarData = new ApiCarData();
        public HttpClient client = new HttpClient();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        #region GET
        [Route("getAllCarsData")]
        [HttpGet]
        public ApiCarData GetAllCarData()
        {
            AgregCarData.Cars = GetCars();
            AgregCarData.Reservations = GetReservations();

            return AgregCarData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("getCarsLocation")]
        [HttpGet]
        public List<Voiture> GetCars()
        {
            List<Voiture> agregCars = new List<Voiture>();

            //Création de la requête pour récupérer les voitures en location
            //API Simon Benjamin
            WebRequest reqCarsApiSimonBenjamin = HttpWebRequest.Create("https://mysterious-eyrie-25660.herokuapp.com/cars");
            reqCarsApiSimonBenjamin.Headers.Add("Authorization", "Bearer " + BEARER_TOKEN);
            reqCarsApiSimonBenjamin.Method = "GET";
            reqCarsApiSimonBenjamin.ContentType = "application/json";
            //Appel de la requête
            HttpWebResponse myHttpWebResponse2 = (HttpWebResponse)reqCarsApiSimonBenjamin.GetResponse();
            var repStream2 = myHttpWebResponse2.GetResponseStream();
            var reader2 = new StreamReader(repStream2);
            List<Automobile> automobiles = JsonConvert.DeserializeObject<List<Automobile>>(reader2.ReadToEnd());

            foreach (Automobile item in automobiles)
            {
                agregCars.Add(new Voiture
                {
                    Id = item.Id,
                    Name = item.Name,
                    Brand = item.Brand,
                    Price = item.DailyPrice,
                    Description = item.Description
                });
            }

            //Création de la requête
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://webservicecar.herokuapp.com/rentals/all");
            req.Method = "GET";
            req.ContentType = "application/json";
            //Appel de la requête
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)req.GetResponse();
            var repStream = myHttpWebResponse.GetResponseStream();
            var reader = new StreamReader(repStream);
            ApiYannigJeremyRoot apiYannigJeremyRoot = JsonConvert.DeserializeObject<ApiYannigJeremyRoot>(reader.ReadToEnd().ToString());

            foreach (RentalList item in apiYannigJeremyRoot._embedded.rentalList)
            {
                agregCars.Add(new Voiture
                {
                    Id = item.id,
                    Name = item.car.name,
                    Brand = item.car.marque,
                    Price = item.price,
                    Description = ""
                });
            }

            return agregCars;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Route("getCarsReservations")]
        [HttpGet]
        public List<Reservation> GetReservations()
        {
            List<Reservation> agregReservations = new List<Reservation>();

            //Création de la requête pour récupérer les réservations de location de voiture 
            //API Simon Benjamin
            WebRequest reqReservationsApiSimonBenjamin = HttpWebRequest.Create("https://mysterious-eyrie-25660.herokuapp.com/reservations");
            reqReservationsApiSimonBenjamin.Headers.Add("Authorization", "Bearer " + BEARER_TOKEN);
            reqReservationsApiSimonBenjamin.Method = "GET";
            reqReservationsApiSimonBenjamin.ContentType = "application/json";
            //Appel de la requête
            HttpWebResponse myHttpWebResponse3 = (HttpWebResponse)reqReservationsApiSimonBenjamin.GetResponse();
            var repStreamReservationsApiSimonBenjamin = myHttpWebResponse3.GetResponseStream();
            var readerReservationsApiSimonBenjamin = new StreamReader(repStreamReservationsApiSimonBenjamin);
            List<Reserv> reversations = JsonConvert.DeserializeObject<List<Reserv>>(readerReservationsApiSimonBenjamin.ReadToEnd());
            
            foreach (Reserv item in reversations)
            {
                agregReservations.Add(new Reservation
                {
                    Id = item.Id,
                    CarId = item.CarId,
                    DateStart = DateTime.Parse(item.Begin),
                    DateEnd = DateTime.Parse(item.End),
                });
            }

            //Création de la requête
            //API Yannig Jeremy
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://webservicecar.herokuapp.com/rentals/all");
            req.Method = "GET";
            req.ContentType = "application/json";
            //Appel de la requête
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)req.GetResponse();
            var repStream = myHttpWebResponse.GetResponseStream();
            var reader = new StreamReader(repStream);
            ApiYannigJeremyRoot apiYannigJeremyRoot = JsonConvert.DeserializeObject<ApiYannigJeremyRoot>(reader.ReadToEnd().ToString());

            foreach (RentalList item in apiYannigJeremyRoot._embedded.rentalList)
            {
                agregReservations.Add(new Reservation
                {
                    Id = item.id,
                    CarId = item.car.id,
                    DateStart = DateTime.Parse(item.departureDate),
                    DateEnd = DateTime.Parse(item.arrivalDate),
                });
            }

            return agregReservations;
        }
        #endregion

        #region POST
        /// <summary>
        /// Pour faire une réservation on se réfère uniquement à l'api de benjamin et simon 
        /// car celle de Yannig et Jeremy ne permet d'éffectuer de réservation
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("doReservCar")]
        public async Task<IHttpActionResult> AgregoReservCar()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", BEARER_TOKEN);

                string json = await Request.Content.ReadAsStringAsync();

                var buffer = System.Text.Encoding.UTF8.GetBytes(json);
                var byteContent = new ByteArrayContent(buffer);

                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage response = client.PostAsync(API_SIMBENJ_URL, byteContent).Result;

                return Ok();
            }
        }
        #endregion
    }
}