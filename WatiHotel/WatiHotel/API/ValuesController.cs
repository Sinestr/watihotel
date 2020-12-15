﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WatiHotel.Models;
using WebService.WatiHotel;

namespace WatiHotel.API
{
    [Route("test")]
    public class ValuesController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();

        Data mesData;


        public Data MesData 
        {
            get
            {
                return JsonConvert.DeserializeObject<Data>(
                    File.ReadAllText(@"D:\FORMATIONS\MASTER - INGINERIE DES AFFAIRES\WEB_SERVICES\TP\0-WatiHotel\watihotel\WatiHotel\WatiHotel\DataJson\webservice_watihotel_json_data.json"));
            }
        }
        

        /// <summary>
        ///     Obtenir 3 listes comportant respectivement les hôtels, les destinations et les réservations
        /// </summary>
        /// <returns></returns>
        [Route("watiHotel")]
        [HttpGet]
        public Data GetAllData()
        {
            return MesData;
        }

        /// <summary>
        ///     Obtenir la liste de tout les hôtels.
        /// </summary>
        /// <returns></returns>
        [Route("watiHotel/hotels")]
        [HttpGet]
        public List<Hotel> GetAllHotels()
        {
            return MesData.Hotels;
        }

        /// <summary>
        ///    Obtenir un hotel par son ID, si aucun hôtel n'existe avec cet ID le résultat sera null
        /// </summary>
        /// <returns></returns>
        [Route("watiHotel/hotel/id/{idHotel}")]
        [HttpGet]
        public Hotel GetHotel(int idHotel)
        {
            Hotel result = null;
            foreach (Hotel unHotel in MesData.Hotels)
            {
                if (unHotel.Id == idHotel)
                {
                    result = unHotel;
                }
            }
            return result;
        }

        /// <summary>
        ///    Obtenir un hotel par son nom, si aucun hôtel n'existe avec ce nom le résultat sera null
        /// </summary>
        /// <returns></returns>
        [Route("watiHotel/hotel/nom/{nomHotel}")]
        [HttpGet]
        public Hotel GetHotel(string nomHotel)
        {
            Hotel result = null;
            foreach (Hotel unHotel in MesData.Hotels)
            {
                if (unHotel.Name.ToLower() == nomHotel.ToLower())
                {
                    result = unHotel;
                }
            }
            return result;
        }

        /// <summary>
        ///    Obtenir les réservations d'un hôtel par son id
        /// </summary>
        /// <returns></returns>
        [Route("watiHotel/hotel/{idHotel}/reservations")]
        [HttpGet]
        public List<Reservation> GetHotelReservations(int idHotel)
        {
            List<Reservation> result = new List<Reservation>()
                ;
            foreach (Reservation uneReservation in MesData.Reservations)
            {
                if (uneReservation.Hotel == idHotel)
                {
                    result.Add(uneReservation);
                }
            }
            return result;
        }

        /// <summary>
        ///     Obtenir la liste des réservations
        /// </summary>
        /// <returns></returns>
        [Route("watiHotel/reservations")]
        [HttpGet]
        public List<Reservation> GetAllReservations()
        {
            return mesData.Reservations;
        }

        /// <summary>
        ///    Obtenir une reservation par son ID, si aucune réservation n'existe avec cet ID le résultat sera null
        /// </summary>
        /// <returns></returns>
        [Route("watiHotel/reservation/id/{idReservation}")]
        [HttpGet]
        public Reservation GetReservation(int idReservation)
        {
            Reservation result = null;
            foreach (Reservation uneReservation in MesData.Reservations)
            {
                if (uneReservation.Id == idReservation)
                {
                    result = uneReservation;
                }
            }
            return result;
        }


        [Route("watiHotel/destinations")]
        [HttpGet]
        public List<Destination> GetAllDestinations()
        {
            return mesData.Destinations;
        }

        /// <summary>
        ///    Obtenir une destination par son ID, si aucune destination n'existe avec cet ID le résultat sera null
        /// </summary>
        /// <returns></returns>
        [Route("watiHotel/destination/id/{idDestination}")]
        [HttpGet]
        public Destination GetDestination(int idDestination)
        {
            Destination result = null;
            foreach (Destination uneDestination in MesData.Destinations)
            {
                if (uneDestination.Id == idDestination)
                {
                    result = uneDestination;
                }
            }
            return result;
        }

        // POST api/<controller>
        [HttpPost]
        public void doRevervation([FromBody] Reservation newReservation)
        {
            List<Reservation> allReservations = mesData.Reservations;
            List<Hotel> allHotels = mesData.Hotels;

            //chercher l'hôtel par l'id et exec reserv dans le model de l'hôtel
           

            if (true)
            {

                allReservations.Add(newReservation);
            }


        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }
    }
}