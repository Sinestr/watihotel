using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WatiAgreg.Models
{
    [DataContract]
    [JsonObject(MemberSerialization.OptOut)]
    public class AvionMP
    {
        #region Fields
        private int id;
        private string name;
        private DateTime created_at;
        private DateTime updated_at;
        #endregion

        #region Constructor
        public AvionMP() { }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }
        #endregion
    }
}