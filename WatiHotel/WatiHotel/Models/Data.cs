using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebService.WatiHotel;

namespace WatiHotel.Models
{
    [DataContract]
    [JsonObject(MemberSerialization.OptOut)]
    public class Data
    {
        #region Fields
        List<Hotel> hotels;
        List<Destination> destinations;
        List<Reservation> reservations;
        #endregion

        #region Constructor
        public Data() { }
        #endregion

        #region Properties
        public List<Hotel> Hotels { get => hotels; set => hotels = value; }
        public List<Destination> Destinations { get => destinations; set => destinations = value; }
        public List<Reservation> Reservations { get => reservations; set => reservations = value; }

        #endregion
    }
}