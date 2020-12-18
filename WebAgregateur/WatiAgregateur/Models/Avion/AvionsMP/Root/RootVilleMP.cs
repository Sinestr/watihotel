using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.AvionsMP
{
    public class RootVilleMP
    {
        [JsonProperty("links")]
        public LinksMP Links { get; set; }

        [JsonProperty("data")]
        public List<VilleMP> Data { get; set; }
    }
}