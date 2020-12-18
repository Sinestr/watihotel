using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatiAgregateur.Models.AvionsMP;

namespace WatiAgregateur.Models.Avion.AvionsKM.Root
{
    public class RootReservationKM
    {
        [JsonProperty("@context")]
        public string Context { get; set; }

        [JsonProperty("@id")]
        public string Id { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("hydra:member")]
        public List<ReservationKM> Reservations { get; set; }

        [JsonProperty("hydra:totalItems")]
        public int ReservationsTotalItems { get; set; }
    }
}