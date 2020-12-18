using Newtonsoft.Json;
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
using System.Web.Http.Cors;
using WatiHotel.Models;
using WebService.WatiHotel;

namespace WatiHotel.API
{
    [Route("watiapi")]
    [EnableCors(origins: "http://watihotelapi.azurewebsites.net/", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        private static readonly HttpClient client = new HttpClient();

        Data MesData = JsonConvert.DeserializeObject<Data>(
                    File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DataJson\\webservice_watihotel_json_data.json")));

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
            return MesData.Reservations;
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


        /// <summary>
        ///     Obtenir la liste des destinations
        /// </summary>
        /// <returns></returns>
        [Route("watiHotel/destinations")]
        [HttpGet]
        public List<Destination> GetAllDestinations()
        {
            return MesData.Destinations;
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

        /// <summary>
        ///     Permet de créer une nouvelle reservation selon les disponibilités de l'hôtel
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        // POST api/<controller>
        [Route("reservation")]
        [HttpPost]
        public Response PostReservation(DateTime date_debut, DateTime date_fin, int id_hotel)
        {
            //Response contenant le type de réponse et le message
            Response result = new Response("","");

            Boolean estDisponible = false;

            Hotel monHotel = MesData.Hotels.Find(Hotel => Hotel.Id == id_hotel);

            //check si l'hôtel de la réservation existe bien
            if (monHotel != null)
            {
                // On instancie la collection de dispon si elle est vide
                if (monHotel.Disponibilites == null)
                {
                    monHotel.Disponibilites = new List<Disponible>();
                }
                //Pour chaque jour dans cette période de reservation
                foreach (DateTime day in EachDay(date_debut, date_fin))
                {
                    
                    Disponible uneDisponible;
                    // Si un objet disponible pour la date en cours existe
                    if(monHotel.Disponibilites.Find(Disponible => Disponible.Date_Room == day) != null) 
                    {
                        uneDisponible = monHotel.Disponibilites.Find(Disponible => Disponible.Date_Room == day);
                    }
                    else //Sinon on la créer
                    {
                        uneDisponible = null;
                    }

                    if (uneDisponible != null)
                    {
                        if (uneDisponible.Room_available > 0) //On retire 1 au nombre total de chambre pour cette dispo
                        {
                            estDisponible = true;
                            uneDisponible.Room_available = uneDisponible.Room_available - 1;
                        }
                        else //Sinon pas disponible
                        {
                            estDisponible = false;
                            result = new Response("error: Not Available", "Plus de chambre disponible à cette période");
                        }
                    }
                    else
                    {
                        // Si la dispo n'existe pas encore dans la collection des dispos de l'hôtel
                        monHotel.Disponibilites.Add(new Disponible
                        {
                            Date_Room = day,
                            Room_available = monHotel.Room_max - 1
                        });
                        estDisponible = true;
                    }
                }
                
            }
            else
            {
                result = new Response("error: Not Available", "L'hôtel n'existe pas. Veuillez choisir un hôtel présent sur le liste !");
            }

            if (estDisponible)
            {
                //ajout de la réservation
                MesData.Reservations.Add(new Reservation
                {
                    Id = MesData.Reservations.Count() + 1,
                    Date_start = date_debut,
                    Date_end = date_fin,
                    Hotel = id_hotel,
                    Status = false,
                });
                result = new Response("Success: Reserversation complete", "La réservation pour l'hôtel " + monHotel.Name + " a bien été prise en compte !");
            }
            MesData.Save();
            return result;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {

        }

        #region Methods
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        #endregion
    }
}