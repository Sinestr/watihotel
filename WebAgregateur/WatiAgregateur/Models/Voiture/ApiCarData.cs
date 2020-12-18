using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WatiAgregateur.Models.Voiture
{
    [DataContract]
    [JsonObject(MemberSerialization.OptOut)]
    public class ApiCarData
    {
        #region Fields
        private List<Voiture> Cars;
        private List<Reservation> Reservations;
        #endregion

        #region Properties
        public List<Voiture> Cars1 { get => Cars; set => Cars = value; }
        public List<Reservation> Reservations1 { get => Reservations; set => Reservations = value; }
        #endregion

        #region Constructors
        public ApiCarData() { }
        #endregion
    }
}