using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WatiAgregateur.Models.Voiture.Abstract;

namespace WatiAgregateur.Models.Voiture
{
    [DataContract]
    [JsonObject(MemberSerialization.OptOut)]
    public class Reservation : IReservation
    {
        #region Fields
        private int _Id;
        private int _CarId;
        private DateTime _DateStart;
        private DateTime _DateEnd;
        #endregion

        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int CarId { get => _CarId; set => _CarId = value; }
        public DateTime DateStart { get => _DateStart; set => _DateStart = value; }
        public DateTime DateEnd { get => _DateEnd; set => _DateEnd = value; }
        #endregion

        #region Constructors
        public Reservation() { }
        #endregion
    }
}