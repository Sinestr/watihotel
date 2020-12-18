using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.AvionsMP
{
    public class VolMP
    {
        #region Fields
        int id;
        int plane_id;
        float price;
        int available_seats;
        DateTime date;
        int start_city_id;
        int end_city_id;
        bool is_full;
        DateTime created_at;
        DateTime updated_at;
        #endregion

        #region Constructor
        public VolMP() { }
        #endregion

        #region Properties
        public int Id { get => id; set => id = value; }
        public int Plane_id { get => plane_id; set => plane_id = value; }
        public float Price { get => price; set => price = value; }
        public int Available_seats { get => available_seats; set => available_seats = value; }
        public DateTime Date { get => date; set => date = value; }
        public int Start_city_id { get => start_city_id; set => start_city_id = value; }
        public int End_city_id { get => end_city_id; set => end_city_id = value; }
        public bool Is_full { get => is_full; set => is_full = value; }
        public DateTime Created_at { get => created_at; set => created_at = value; }
        public DateTime Updated_at { get => updated_at; set => updated_at = value; }
        #endregion

    }
}