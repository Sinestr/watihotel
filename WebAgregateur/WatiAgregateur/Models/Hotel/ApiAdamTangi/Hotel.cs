using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.Hotel.ApiAdamTangi
{
    public class Hotel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Descritpion")]
        public object Descritpion { get; set; }

        [JsonProperty("Address")]
        public string Address { get; set; }

        [JsonProperty("Price")]
        public double Price { get; set; }

        [JsonProperty("Room_max")]
        public int RoomMax { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

        [JsonProperty("Destination")]
        public int Destination { get; set; }

        [JsonProperty("Disponibilites")]
        public object Disponibilites { get; set; }
    }
}