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
    [Route("watiAgrega/Villes")]
    public class VillesController : ApiController
    {
        APIController monAPIController = new APIController();

        [Route("GetVilles")]
        [HttpGet]
        public List<Ville> GetVilles()
        {
            List<Ville> result = new List<Ville>();
            int unID = 0;

            //On cherche toute les villes depuis l'API de Marine et Peter
            RootVilleMP maRootMP = GetVilleMP();

            //Pour chaque avion de leur API, on créer une ville selon nos critères et on l'ajoute à notre collection "result"
            foreach (VilleMP uneVilleMP in maRootMP.Data)
            {
                result.Add(new Ville()
                {
                    Id = unID,
                    Nom = uneVilleMP.Name,
                    TypeAPI = "VilleMP"
                });
                unID++;
            }

            //On cherche toute les villes depuis l'API de Kévin et Morgan
            RootLocationKM maRootKM = GetVilleKM();

            //Pour chaque avion de leur API, on créer une ville selon nos critères et on l'ajoute à notre collection "result"
            foreach (LocationKM uneLocationKM in maRootKM.Locations)
            {
                result.Add(new Ville()
                {
                    Id = unID,
                    Nom = uneLocationKM.Label,
                    TypeAPI = "LocationKM"
                });
                unID++;
            }


            return result;
        }

        /// <summary>
        ///     Permet de récupérer toute les villes de l'API de Marine et Peter
        /// </summary>
        /// <returns></returns>
        public RootVilleMP GetVilleMP()
        {
            List<string> mesHeaders = new List<string>();
            mesHeaders.Add("Api-token:" + "ZPDpXWyKDeavzEDXtMHip89eGN9gSuRzasoDrTc9vKo27YIxJ9");

            RootVilleMP maRootMP = new RootVilleMP()
            {
                Links = new LinksMP(),
                Data = new List<VilleMP>()
            };

            var repStream = monAPIController.ReqAPI("GET", "https://trivaphp.herokuapp.com/api/cities", mesHeaders).GetResponseStream();
            var reader = new StreamReader(repStream);
            maRootMP = JsonConvert.DeserializeObject<RootVilleMP>(reader.ReadToEnd().ToString());

            return maRootMP;
        }

        /// <summary>
        ///     Permet de récupérer toute les villes de l'API de Kévin et Morgan
        /// </summary>
        /// <returns></returns>
        public RootLocationKM GetVilleKM()
        {
            List<string> mesHeaders = new List<string>();

            RootLocationKM maRootKM = new RootLocationKM()
            {
               Locations = new List<LocationKM>()
            };

            var repStream = monAPIController.ReqAPI("GET", "https://tp-api-rest-service-avion.herokuapp.com/index.php/api/locations", mesHeaders).GetResponseStream();
            var reader = new StreamReader(repStream);
            maRootKM = JsonConvert.DeserializeObject<RootLocationKM>(reader.ReadToEnd().ToString());

            return maRootKM;
        }

    }
}

