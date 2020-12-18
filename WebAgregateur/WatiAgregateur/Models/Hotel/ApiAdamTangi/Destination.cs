using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.Hotel.ApiAdamTangi
{
    public class Destination
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("City")]
        public string City { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }
    }
}