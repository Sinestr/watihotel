using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiAgregateur.Models.Voiture.ApiYannigJeremy
{
    public class RentalList
    {
        public int id { get; set; }
        public string customerName { get; set; }
        public Car car { get; set; }
        public string departureDate { get; set; }
        public string arrivalDate { get; set; }
        public double price { get; set; }
        public Links _links { get; set; }
    }
}