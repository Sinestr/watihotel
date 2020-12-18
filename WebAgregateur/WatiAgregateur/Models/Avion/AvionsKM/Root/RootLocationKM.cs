using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatiAgregateur.Models.AvionsMP;

namespace WatiAgregateur.Models.Avion.AvionsKM.Root
{
    public class RootLocationKM
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("hydra:member")]
        public List<LocationKM> Locations { get; set; }

        [JsonProperty("hydra:totalItems")]
        public int LocationsTotalItems { get; set; }
    }
}