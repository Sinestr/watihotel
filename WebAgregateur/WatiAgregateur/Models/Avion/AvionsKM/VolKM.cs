using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.Avion.AvionsKM.Root
{
    public class VolKM
    {
        [JsonProperty("@id")]
        public string url { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("departureDate")]
        public DateTime DepartureDate { get; set; }

        [JsonProperty("price")]
        public float Price { get; set; }

        [JsonProperty("plane")]
        public string Plane { get; set; }

        [JsonProperty("departurePoint")]
        public string DeparturePoint { get; set; }

        [JsonProperty("arrivalPoint")]
        public string ArrivalPoint { get; set; }

        [JsonProperty("reservations")]
        public List<string> Reservations { get; set; }
    }
}