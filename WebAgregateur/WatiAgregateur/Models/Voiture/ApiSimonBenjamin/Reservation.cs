using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WatiAgregateur.Models.Voiture.ApiSimonBenjamin
{
    [DataContract]
    [JsonObject(MemberSerialization.OptOut)]
    public class Reservation
    {
        #region Fields
        private int _Id;
        private int _CarId;
        private DateTime _Begin;
        private DateTime _End;
        #endregion

        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int CarId { get => _CarId; set => _CarId = value; }
        public DateTime Begin { get => _Begin; set => _Begin = value; }
        public DateTime End { get => _End; set => _End = value; }
        #endregion

        #region Construct
        public Reservation() { }
        #endregion
    }
}