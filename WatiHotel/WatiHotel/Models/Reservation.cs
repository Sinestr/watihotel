using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.ServiceModel.Web;
using Newtonsoft.Json;

namespace WebService.WatiHotel
{
    [DataContract]
    [JsonObject(MemberSerialization.OptOut)]
    public class Reservation
    {
        #region Fields
        /// <summary>
        /// Idenitifaint unique
        /// </summary>
        private int id;

        /// <summary>
        /// Date de début de la réservation
        /// </summary>
        private DateTime date_start;

        /// <summary>
        /// Date de fin de la réservation
        /// </summary>
        private DateTime date_end;

        /// <summary>
        /// Permet de savoir si la reservation a été payée ou non
        /// true = payée
        /// false = non payée
        /// </summary>
        private bool status;

        /// <summary>
        /// Hotel associé à la réservation
        /// </summary>
        private Hotel hotel;


        #endregion

        #region Properties
        /// <summary>
        /// Obtient l'identifiant de la réservation
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Obtient la date de début de la réservation
        /// </summary>
        public DateTime Date_start { get => date_start; set => date_start = value; }

        /// <summary>
        /// Obtient la date de fin de la réservation
        /// </summary>
        public DateTime Date_end { get => date_end; set => date_end = value; }

        /// <summary>
        /// Obtient l'hotel associé à la réservation
        /// </summary>
        public Hotel Hotel { get => hotel; set => hotel = value; }

        /// <summary>
        /// Obtient le statut de la réservation
        /// </summary>
        public bool Status { get => status; set => status = value; }
        #endregion
    }
}