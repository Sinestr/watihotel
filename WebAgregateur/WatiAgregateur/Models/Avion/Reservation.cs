using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.Avion
{
    public class Reservation
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("seats")]
        public int nbrPlaces { get; set; }

        [JsonProperty("flightID")]
        public int FlightID { get; set; }

        [JsonProperty("buyer_name")]
        public string auNomDe { get; set; }

        [JsonProperty("typeAPI")]
        public string TypeAPI { get; set; }
    }
}