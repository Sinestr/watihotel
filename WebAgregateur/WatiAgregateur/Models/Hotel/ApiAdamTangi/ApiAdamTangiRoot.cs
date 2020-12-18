using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.Hotel.ApiAdamTangi
{
    public class ApiAdamTangiRoot
    {
        [JsonProperty("Hotels")]
        public List<Hotel> Hotels { get; set; }

        [JsonProperty("Destinations")]
        public List<Destination> Destinations { get; set; }

        [JsonProperty("Reservations")]
        public List<Reservation> Reservations { get; set; }
    }
}