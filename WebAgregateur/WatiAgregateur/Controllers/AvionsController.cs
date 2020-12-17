using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace WatiAgregateur.Controllers
{
    [Route("watiAgrega/Avions")]
    public class AvionsController : ApiController
    {
        [Route("GetAvions")]
        [HttpGet]
        public string GetAvions()
        {
            //Préparation de la requête
            string method = "GET";
            string query = "https://trivaphp.herokuapp.com/api/planes";
            //Création de la requête
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(query);
            req.Method = method;
            req.ContentType = "application/json";
            req.Headers.Add("Api-token:" + "ZPDpXWyKDeavzEDXtMHip89eGN9gSuRzasoDrTc9vKo27YIxJ9");
            //Appel de la requête
            HttpWebResponse myHttpWebResponse = (HttpWebResponse)req.GetResponse();

            var repStream = myHttpWebResponse.GetResponseStream();
            var reader = new StreamReader(repStream);
            return reader.ReadToEnd();
        }

        [Route("Get")]
        [HttpGet]
        public string Get()
        {
            return "toto et si c'est déjà prit, return titi";
        }

    }
}