using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.Hotel.ApiAdamTangi
{
    public class Reservation
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Date_start")]
        public DateTime DateStart { get; set; }

        [JsonProperty("Date_end")]
        public DateTime DateEnd { get; set; }

        [JsonProperty("Hotel")]
        public int Hotel { get; set; }

        [JsonProperty("Status")]
        public bool Status { get; set; }
    }
}