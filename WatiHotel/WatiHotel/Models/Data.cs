using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WebService.WatiHotel;

namespace WatiHotel.Models
{
    [DataContract]
    [JsonObject(MemberSerialization.OptOut)]
    public class Data
    {
        #region Fields
        List<Hotel> hotels;
        List<Destination> destinations;
        List<Reservation> reservations;
        #endregion

        #region Constructor
        public Data()
        {
            /*
            List<Destination> destinations = new List<Destination>();
            List<Hotel> hotels = new List<Hotel>();
            List<Reservation> Reservations = new List<Reservation>();

            Destination uneDestinationA = new Destination();
            uneDestinationA.City = "LosAngeles";
            uneDestinationA.Country = "USA";
            uneDestinationA.Id = 1;

            Hotel unHotelA = new Hotel();
            unHotelA.Id = 1;
            unHotelA.Name = "Foruml1";
            unHotelA.Price = 40.00;
            unHotelA.Room_available = 10;
            unHotelA.Room_max = 12;
            unHotelA.Address = "425 Evergreen Terasse";
            unHotelA.Destination = 1;

            hotels.Add(unHotelA);
            hotels.Add(unHotelA);
            destinations.Add(uneDestinationA);
            this.Hotels = hotels;
            this.Destinations = destinations;
            */
            
        }
        #endregion

        #region Properties
        public List<Hotel> Hotels { get => hotels; set => hotels = value; }
        public List<Destination> Destinations { get => destinations; set => destinations = value; }
        public List<Reservation> Reservations { get => reservations; set => reservations = value; }

        #endregion
    }
}