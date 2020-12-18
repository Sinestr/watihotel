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
    public class Reserv
    {
        #region Fields
        [JsonProperty("id")]
        private int _Id;

        [JsonProperty("carId")]
        private int _CarId;

        [JsonProperty("begin")]
        private string _Begin;

        [JsonProperty("end")]
        private string _End;
        #endregion

        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public int CarId { get => _CarId; set => _CarId = value; }
        public string Begin { get => _Begin; set => _Begin = value; }
        public string End { get => _End; set => _End = value; }
        #endregion

        #region Construct
        public Reserv() { }
        #endregion
    }
}