using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using WatiAgregateur.Controllers.Avions;
using WatiAgregateur.Models;
using WatiAgregateur.Models.Avion;
using WatiAgregateur.Models.Avion.AvionsKM;
using WatiAgregateur.Models.Avion.AvionsKM.Root;
using WatiAgregateur.Models.AvionsMP;

namespace WatiAgregateur.Controllers
{
    [Route("watiAgrega/Reservations")]
    public class ReservationsController : ApiController
    {
        APIController monAPIController = new APIController();

        [Route("GetReservations")]
        [HttpGet]
        public List<Reservation> GetReservations()
        {
            List<Reservation> result = new List<Reservation>();
            int unID = 0;

            //On cherche toute les reservations depuis l'API de Marine et Peter
            RootReservationMP maRootMP = GetReservationMP();

            //Pour chaque avion de leur API, on créer une reservation selon nos critères et on l'ajoute à notre collection "result"
            foreach (ReservationMP uneReservationMP in maRootMP.Data)
            {
                result.Add(new Reservation()
                {
                    Id = unID,
                    auNomDe = uneReservationMP.BuyerName,
                    nbrPlaces = int.Parse(uneReservationMP.Seats),
                    FlightID = uneReservationMP.FlightId,
                    TypeAPI = "ReservationMP"
                });
                unID++;
            }

            //On cherche toute les reservations depuis l'API de Kévin et Morgan
            RootReservationKM maRootKM = GetReservationKM();

            //Pour chaque avion de leur API, on créer une reservation selon nos critères et on l'ajoute à notre collection "result"
            foreach (ReservationKM uneReservationKM in maRootKM.Reservations)
            {
                result.Add(new Reservation()
                {
                    Id = unID,
                    auNomDe = "",
                    nbrPlaces = uneReservationKM.Seats,
                    FlightID = int.Parse(uneReservationKM.Flight.Substring(uneReservationKM.Flight.LastIndexOf("/")+1)),
                    TypeAPI = "ReservationKM"
                });
                unID++;
            }
            return result;
        }


        [Route("PostReservationMP")]
        [HttpPost]
        public string PostReservationMP(string buyer_name, int flight_id, int seats)
        {

            List<string> mesHeaders = new List<string>();
            mesHeaders.Add("Api-token:" + "ZPDpXWyKDeavzEDXtMHip89eGN9gSuRzasoDrTc9vKo27YIxJ9");

            RootVolMP maRootMP = new RootVolMP()
            {
                Links = new LinksMP(),
                Data = new List<VolMP>()
            };

            return monAPIController.ReqAPI("POST", "https://trivaphp.herokuapp.com/api/reservations/add?buyer_name=" + buyer_name + "&flight_id=" + flight_id + "&seats=" + seats, mesHeaders).StatusCode.ToString();
        }

        /// <summary>
        ///     Permet de récupérer toute les reservations de l'API de Marine et Peter
        /// </summary>
        /// <returns></returns>
        public RootReservationMP GetReservationMP()
        {
            List<string> mesHeaders = new List<string>();
            mesHeaders.Add("Api-token:" + "ZPDpXWyKDeavzEDXtMHip89eGN9gSuRzasoDrTc9vKo27YIxJ9");

            RootReservationMP maRootMP = new RootReservationMP()
            {
                Links = new LinksMP(),
                Data = new List<ReservationMP>()
            };

            var repStream = monAPIController.ReqAPI("GET", "https://trivaphp.herokuapp.com/api/reservations", mesHeaders).GetResponseStream();
            var reader = new StreamReader(repStream);
            maRootMP = JsonConvert.DeserializeObject<RootReservationMP>(reader.ReadToEnd().ToString());

            return maRootMP;
        }

        /// <summary>
        ///     Permet de récupérer toute les reservations de l'API de Kévin et Morgan
        /// </summary>
        /// <returns></returns>
        public RootReservationKM GetReservationKM()
        {
            List<string> mesHeaders = new List<string>();

            RootReservationKM maRootKM = new RootReservationKM()
            {
                Reservations = new List<ReservationKM>()
            };

            var repStream = monAPIController.ReqAPI("GET", "https://tp-api-rest-service-avion.herokuapp.com/index.php/api/reservations", mesHeaders).GetResponseStream();
            var reader = new StreamReader(repStream);
            maRootKM = JsonConvert.DeserializeObject<RootReservationKM>(reader.ReadToEnd().ToString());

            return maRootKM;
        }

    }
}

