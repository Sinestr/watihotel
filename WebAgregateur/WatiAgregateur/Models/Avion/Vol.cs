using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.Avion
{
    public class Vol
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("date")]
        public DateTime Date { get; set; }

        [JsonProperty("price")]
        public float Prix { get; set; }

        [JsonProperty("plane")]
        public int AvionID { get; set; }

        [JsonProperty("start_city_id")]
        public int VilleDepartID { get; set; }

        [JsonProperty("end_city_id")]
        public int VilleArriveeID { get; set; }

        [JsonProperty("typeAPI")]
        public string TypeAPI { get; set; }
    }
}