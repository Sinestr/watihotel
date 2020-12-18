using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.Avion.AvionsKM
{
    public class LocationKM
    {
        [JsonProperty("@id")]
        public string url { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("departures")]
        public List<string> Departures { get; set; }

        [JsonProperty("arrivals")]
        public List<string> Arrivals { get; set; }
    }
}