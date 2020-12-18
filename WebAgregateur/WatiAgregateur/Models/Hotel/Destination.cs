using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WatiAgregateur.Models.Hotel.Abstract;

namespace WatiAgregateur.Models.Hotel
{
    [DataContract]
    [JsonObject(MemberSerialization.OptOut)]
    public class Destination : IDestination
    {
        #region Fields
        private int _Id;
        private string _City;
        private string _Country;
        #endregion

        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public string City { get => _City; set => _City = value; }
        public string Country { get => _Country; set => _Country = value; }
        #endregion

        #region Constructors
        public Destination() { }
        #endregion
    }
}