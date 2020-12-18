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
    [Route("watiAgrega/Vols")]
    public class VolsController : ApiController
    {
        APIController monAPIController = new APIController();

        [Route("GetVols")]
        [HttpGet]
        public List<Vol> GetVols()
        {
            List<Vol> result = new List<Vol>();
            int unID = 0;

            //On cherche toute les Vols depuis l'API de Marine et Peter
            RootVolMP maRootMP = GetVolMP();

            //Pour chaque avion de leur API, on créer une Vol selon nos critères et on l'ajoute à notre collection "result"
            foreach (VolMP uneVolMP in maRootMP.Data)
            {
                result.Add(new Vol()
                {
                    Id = unID,
                    AvionID = uneVolMP.Plane_id,
                    Date = uneVolMP.Date,
                    Prix = uneVolMP.Price,
                    VilleDepartID = uneVolMP.Start_city_id,
                    VilleArriveeID = uneVolMP.End_city_id,
                    TypeAPI = "VolMP"
                });
                unID++;
            }

            //On cherche toute les Vols depuis l'API de Kévin et Morgan
            RootVolKM maRootKM = GetVolKM();

            //Pour chaque avion de leur API, on créer une Vol selon nos critères et on l'ajoute à notre collection "result"
            foreach (VolKM uneVolKM in maRootKM.Vols)
            {
                result.Add(new Vol()
                {
                    Id = unID,
                    AvionID = int.Parse(uneVolKM.Plane.Substring(uneVolKM.Plane.LastIndexOf("/") + 1)),
                    Date = uneVolKM.DepartureDate,
                    Prix = uneVolKM.Price,
                    VilleDepartID = int.Parse(uneVolKM.DeparturePoint.Substring(uneVolKM.DeparturePoint.LastIndexOf("/") + 1)),
                    VilleArriveeID = int.Parse(uneVolKM.ArrivalPoint.Substring(uneVolKM.ArrivalPoint.LastIndexOf("/") + 1)),
                    TypeAPI = "VolKM"
                });
                unID++;
            }


            return result;
        }

        /// <summary>
        ///     Permet de récupérer toute les Vols de l'API de Marine et Peter
        /// </summary>
        /// <returns></returns>
        public RootVolMP GetVolMP()
        {
            List<string> mesHeaders = new List<string>();
            mesHeaders.Add("Api-token:" + "ZPDpXWyKDeavzEDXtMHip89eGN9gSuRzasoDrTc9vKo27YIxJ9");

            RootVolMP maRootMP = new RootVolMP()
            {
                Links = new LinksMP(),
                Data = new List<VolMP>()
            };

            var repStream = monAPIController.ReqAPI("GET", "https://trivaphp.herokuapp.com/api/flights", mesHeaders).GetResponseStream();
            var reader = new StreamReader(repStream);
            maRootMP = JsonConvert.DeserializeObject<RootVolMP>(reader.ReadToEnd().ToString());

            return maRootMP;
        }

        /// <summary>
        ///     Permet de récupérer toute les Vols de l'API de Kévin et Morgan
        /// </summary>
        /// <returns></returns>
        public RootVolKM GetVolKM()
        {
            List<string> mesHeaders = new List<string>();

            RootVolKM maRootKM = new RootVolKM()
            {
               Vols = new List<VolKM>()
            };

            var repStream = monAPIController.ReqAPI("GET", "https://tp-api-rest-service-avion.herokuapp.com/index.php/api/flights", mesHeaders).GetResponseStream();
            var reader = new StreamReader(repStream);
            maRootKM = JsonConvert.DeserializeObject<RootVolKM>(reader.ReadToEnd().ToString());

            return maRootKM;
        }

    }
}

