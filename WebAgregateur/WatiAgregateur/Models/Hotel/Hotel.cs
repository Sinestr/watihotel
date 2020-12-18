using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatiAgregateur.Models.Hotel.Abstract;

namespace WatiAgregateur.Models.Hotel
{
    public class Hotel : IHotel
    {
        #region Fields
        private int _Id;
        private string _Name;
        private object _Descritpion;
        private string _Address;
        private double _Price;
        private int _RoomMax;
        private int _Destination;
        private object _Disponibilites;
        #endregion

        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public string Name { get => _Name; set => _Name = value; }
        public object Descritpion { get => _Descritpion; set => _Descritpion = value; }
        public string Address { get => _Address; set => _Address = value; }
        public double Price { get => _Price; set => _Price = value; }
        public int RoomMax { get => this._RoomMax; set => this._RoomMax = value; }
        public int Destination { get => this._Destination; set => this._Destination = value; }
        public object Disponibilites { get => this._Disponibilites; set => this._Disponibilites = value; }
        #endregion

        #region Constructors
        public Hotel() { }
        #endregion
    }
}