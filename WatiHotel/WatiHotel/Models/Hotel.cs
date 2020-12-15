using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WebService.WatiHotel
{
    [DataContract]
    [JsonObject(MemberSerialization.OptOut)]
    public class Hotel
    {
        #region Fields
        /// <summary>
        /// Identifiant unique
        /// </summary>
        private int id;

        /// <summary>
        /// Nom de l'hotel
        /// </summary>
        private string name;

        /// <summary>
        /// Courte description de l'hotel
        /// </summary>
        private string descritpion;

        /// <summary>
        /// Adresse complète de l'hotel (n° voie + rue)
        /// </summary>
        private string address;

        /// <summary>
        /// Prix d'une réservation pour une chambre
        /// </summary>
        private double price;

        /// <summary>
        /// Nombre de chambres encore disponible dans l'hôtel
        /// </summary>
        private int room_available;

        /// <summary>
        /// Nombre de chambre maximum disponible dans l'hôtel
        /// </summary>
        private int room_max;

        /// <summary>
        /// Image de présentation de l'hôtel
        /// </summary>
        private string image;

        /// <summary>
        /// Destination liée à l'hôtel (ville / pays)
        /// </summary>
        private int idDestination;

        #endregion


        #region Properties
        /// <summary>
        /// Obtient l'identifiant de l'hôtel
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Obtient le nom de l'hôtel
        /// </summary>
        public string Name { get => name; set => name = value; }

        /// <summary>
        /// Obtient la description de l'hôtel
        /// </summary>
        public string Descritpion { get => descritpion; set => descritpion = value; }

        /// <summary>
        /// Obtient l'adresse complète de l'hôtel (n° voie + rue)
        /// </summary>
        public string Address { get => address; set => address = value; }

        /// <summary>
        /// Obtient le prix d'une chambre (le même pour toutes les chambres de l'hôtel)
        /// </summary>
        public double Price { get => price; set => price = value; }

        /// <summary>
        /// Obtient le nombre de chambre encore disponible dans l'hôtel
        /// </summary>
        public int Room_available { get => room_available; set => room_available = value; }

        /// <summary>
        /// Obtient le nombre de chambre maximum disponible dans l'hôtel
        /// </summary>
        public int Room_max { get => room_max; set => room_max = value; }

        /// <summary>
        /// Obitent l'image de présentation de l'hôtel
        /// </summary>
        public string Image { get => image; set => image = value; }

        /// <summary>
        /// Obtient la destination liée à l'hôtel (ville / pays)
        /// </summary>
        public int Destination { get => idDestination; set => idDestination = value; }

        #endregion

        #region Methods 
        /// <summary>
        /// Réservation d'une chambre d'hôtel
        /// </summary>
        public void Start_Reserve()
        {
            //check si au moins une chambre est toujours dispo avant de pouvoir effetcuer la réservation
            if (this.Room_available > 0)
            {
                this.Room_available--;
            }
        }

        /// <summary>
        /// Fin d'une réservation d'une chambre d'hôtel
        /// notament appelée quand la date de réservation est terminée
        /// </summary>
        public void End_Reserve()
        {
            //check si au moins une chambre est toujours dispo avant de pouvoir effetcuer la réservation
            if (this.Room_available > 0 && this.Room_available <= this.Room_max)
            {
                this.Room_available++;
            }
        }
        #endregion
    }
}