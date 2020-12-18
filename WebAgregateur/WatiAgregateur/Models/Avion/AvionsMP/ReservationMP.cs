using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.AvionsMP
{
    public class ReservationMP
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("buyer_name")]
        public string BuyerName { get; set; }

        [JsonProperty("seats")]
        public string Seats { get; set; }

        [JsonProperty("flight_id")]
        public int FlightId { get; set; }

        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public string UpdatedAt { get; set; }
    }
}