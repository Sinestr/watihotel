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
        private List<Voiture> _Cars;
        private List<Reservation> _Reservations;
        #endregion

        #region Properties
        public List<Voiture> Cars { get => this._Cars; set => this._Cars = value; }
        public List<Reservation> Reservations { get => this._Reservations; set => this._Reservations = value; }
        #endregion

        #region Constructors
        public ApiCarData() { }
        #endregion
    }
}