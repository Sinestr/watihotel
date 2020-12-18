using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WatiAgregateur.Models.Hotel.Abstract;

namespace WatiAgregateur.Models.Hotel
{
    public class Reservation : IReservation
    {
        #region Fields
        private int _Id;
        private DateTime _DateStart;
        private DateTime _DateEnd;
        private int _Hotel;
        private bool _Status;
        #endregion

        #region Properties
        public int Id { get => _Id; set => _Id = value; }
        public DateTime DateStart { get => _DateStart; set => _DateStart = value; }
        public DateTime DateEnd { get => _DateEnd; set => _DateEnd = value; }
        public int Hotel { get => _Hotel; set => _Hotel = value; }
        public bool Status { get => _Status; set => _Status = value; }
        #endregion

        #region Constructors
        public Reservation() { }
        #endregion
    }
}