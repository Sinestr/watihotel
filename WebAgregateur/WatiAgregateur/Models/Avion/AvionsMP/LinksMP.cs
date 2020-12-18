using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.AvionsMP
{
    public class LinksMP
    {
        [JsonProperty("self")]
        public string Self { get; set; }
    }
}