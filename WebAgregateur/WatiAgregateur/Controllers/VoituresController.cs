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
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using WatiAgregateur.Models.Voiture;
using WatiAgregateur.Models.Voiture.ApiSimonBenjamin;
using WatiAgregateur.Models.Voiture.ApiYannigJeremy;
using Reservation = WatiAgregateur.Models.Voiture.Reservation;

namespace WatiAgregateur.Controllers
{
    [Route("watiAgrega/Voitures")]
    public class VoituresController: ApiController
    {
        HttpClient client = new HttpClient();

        #region GET

        [Route("getCars")]
        [HttpGet]
        public object GetCars()
        {
            //Création de la requête
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://webservicecar.herokuapp.com/rentals/all");
            req.Method = "GET";
            req.ContentType = "application/json";
            //Appel de la requête
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)req.GetResponse();
            var repStream = myHttpWebResponse.GetResponseStream();
            var reader = new StreamReader(repStream);
            ApiYannigJeremyRoot apiYannigJeremyRoot = JsonConvert.DeserializeObject<ApiYannigJeremyRoot>(reader.ReadToEnd().ToString());


            List<Voiture> cars = new List<Voiture>();
            List<Reservation> reservations = new List<Reservation>();

            int index = 0;
            foreach (RentalList item in apiYannigJeremyRoot._embedded.rentalList)
            {
                cars.Add(new Voiture
                {
                    Id = index,
                    Price = item.price,
                    Name = item.car.name,
                    Description = "",
                    Brand = item.car.marque
                });
                index++;

                reservations.Add(new Reservation
                {
                    Id = item.id,
                    CarId = item.car.id,
                    DateStart = DateTime.Parse(item.departureDate),
                    DateEnd = DateTime.Parse(item.arrivalDate),
                });
            }


            //Création de la requête
            WebRequest req2 = HttpWebRequest.Create("https://mysterious-eyrie-25660.herokuapp.com/cars");
            req2.Headers.Add("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6MSwiaWF0IjoxNjA4MjQ1NzE1LCJleHAiOjE2MDgzMzIxMTV9.F19s1WvM_h_k6JsVBTUnCzqwUnvqQ7noVRLbu1ku7Ew");
            req2.Method = "GET";
            req2.ContentType = "application/json";
            
            
            //Appel de la requête
            HttpWebResponse myHttpWebResponse2 = (HttpWebResponse)req2.GetResponse();

            var repStream2 = myHttpWebResponse2.GetResponseStream();
            var reader2 = new StreamReader(repStream2);

            Automobile automobile = JsonConvert.DeserializeObject<Automobile>(reader2.ReadToEnd().ToString());

            return automobile;
        }

        #endregion
    }
}