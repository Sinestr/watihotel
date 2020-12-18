using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.Avion.AvionsKM.Root
{
    public class ReservationKM
    {
        [JsonProperty("@id")]
        public string url { get; set; }

        [JsonProperty("@type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("paymentDate")]
        public DateTime PaymentDate { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("seats")]
        public int Seats { get; set; }

        [JsonProperty("flight")]
        public string Flight { get; set; }
    }
}