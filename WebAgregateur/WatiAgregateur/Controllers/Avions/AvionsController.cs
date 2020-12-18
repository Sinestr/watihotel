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
    [Route("watiAgrega/Avions")]
    public class AvionsController : ApiController
    {
        APIController monAPIController = new APIController();

        [Route("GetAvions")]
        [HttpGet]
        public List<Avion> GetAvions()
        {
            List<Avion> result = new List<Avion>();
            int unID = 0;

            //On cherche tout les avions depuis l'API de Marine et Peter
            RootAvionMP maRootMP = GetAvionMP();

            //Pour chaque avion de leur API, on créer un avion selon nos critères et on l'ajoute à notre collection "result"
            foreach (AvionMP unAvionMP in maRootMP.Data)
            {
                result.Add(new Avion()
                {
                    Id = unID,
                    Name = unAvionMP.Name,
                    Capacity = int.Parse(unAvionMP.Capacity),
                    TypeAPI = "AvionMP"
                });
                unID++;
            }

            //On cherche tout les avions depuis l'API de Kévin et Morgan
            RootAvionKM maRootKM = GetAvionKM();

            //Pour chaque avion de leur API, on créer un avion selon nos critères et on l'ajoute à notre collection "result"
            foreach (AvionKM unAvionKM in maRootKM.Avions)
            {
                result.Add(new Avion()
                {
                    Id = unID,
                    Name = unAvionKM.Label,
                    Capacity = unAvionKM.Seats,
                    TypeAPI = "AvionKM"
                });
                unID++;
            }


            return result;
        }

        /// <summary>
        ///     Permet de récupérer tout les avions de l'API de Marine et Peter
        /// </summary>
        /// <returns></returns>
        public RootAvionMP GetAvionMP()
        {
            List<string> mesHeaders = new List<string>();
            mesHeaders.Add("Api-token:" + "ZPDpXWyKDeavzEDXtMHip89eGN9gSuRzasoDrTc9vKo27YIxJ9");

            RootAvionMP maRootMP = new RootAvionMP()
            {
                Links = new LinksMP(),
                Data = new List<AvionMP>()
            };

            var repStream = monAPIController.ReqAPI("GET", "https://trivaphp.herokuapp.com/api/planes", mesHeaders).GetResponseStream();
            var reader = new StreamReader(repStream);
            maRootMP = JsonConvert.DeserializeObject<RootAvionMP>(reader.ReadToEnd().ToString());

            return maRootMP;
        }

        /// <summary>
        ///     Permet de récupérer tout les avions de l'API de Kévin et Morgan
        /// </summary>
        /// <returns></returns>
        public RootAvionKM GetAvionKM()
        {
            List<string> mesHeaders = new List<string>();

            RootAvionKM maRootKM = new RootAvionKM()
            {
                Avions = new List<AvionKM>()
            };

            var repStream = monAPIController.ReqAPI("GET", "https://tp-api-rest-service-avion.herokuapp.com/index.php/api/planes", mesHeaders).GetResponseStream();
            var reader = new StreamReader(repStream);
            maRootKM = JsonConvert.DeserializeObject<RootAvionKM>(reader.ReadToEnd().ToString());

            return maRootKM;
        }

    }
}

