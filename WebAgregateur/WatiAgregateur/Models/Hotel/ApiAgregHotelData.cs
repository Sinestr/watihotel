using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WatiAgregateur.Models.Hotel
{
    [DataContract]
    [JsonObject(MemberSerialization.OptOut)]
    public class ApiAgregHotelData
    {
        #region Fields
        private List<Hotel> _Hotels;
        private List<Reservation> _Reservations;
        private List<Destination> _Destination;
        #endregion

        #region Properties
        public List<Hotel> Hotels { get => _Hotels; set => _Hotels = value; }
        public List<Reservation> Reservations { get => _Reservations; set => _Reservations = value; }
        public List<Destination> Destination { get => _Destination; set => _Destination = value; }
        #endregion

        #region Constructors
        public ApiAgregHotelData() { }
        #endregion
    }
}