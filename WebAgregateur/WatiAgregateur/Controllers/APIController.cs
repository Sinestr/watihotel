using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WatiAgregateur.Controllers.Avions
{
    public class APIController
    {
        public APIController() {}
        public HttpWebResponse ReqAPI(string method, string query, List<string> headers)
        {
            //Création de la requête
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(query);
            req.Method = method;
            req.ContentType = "application/json";
            foreach (string monHeader in headers)
            {
                req.Headers.Add(monHeader);
            }
            //Appel de la requête
            HttpWebResponse rep = (HttpWebResponse)req.GetResponse();
            return rep;
        }
    }
}