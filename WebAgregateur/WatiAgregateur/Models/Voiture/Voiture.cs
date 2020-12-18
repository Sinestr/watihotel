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
    public class Voiture : ICar
    {
        #region Fields
        private int _Id;
        private string _Name;
        private string _Brand;
        private string _Description;
        private double _Price;
        #endregion

        #region Propoerties
        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Brand { get => _Brand; set => _Brand = value; }
        public string Description { get => _Description; set => _Description = value; }
        public double Price { get => _Price; set => _Price = value; }
        #endregion

        #region Constructors
        public Voiture() { }
        #endregion
    }
}