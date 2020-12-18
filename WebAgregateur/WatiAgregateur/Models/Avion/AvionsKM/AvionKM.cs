using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.Avion.AvionsKM
{
    public class AvionKM
    {
        [JsonProperty("@id")]
        public string url { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("seats")]
        public int Seats { get; set; }

        [JsonProperty("flights")]
        public List<string> Flights { get; set; }
    }
}