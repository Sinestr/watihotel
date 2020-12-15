using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace WebService.WatiHotel
{
    [DataContract]
    [JsonObject(MemberSerialization.OptOut)]
    public class Destination
    {
        #region Fields
        /// <summary>
        /// Idenitifaint unique
        /// </summary>
        private int id;

        /// <summary>
        /// Ville de la destination
        /// </summary>
        private string city;

        /// <summary>
        /// Pays de la destination
        /// </summary>
        private string country;

        /// <summary>
        /// Image de présentation de la destintation
        /// </summary>
        private string image;


        #endregion

        #region Porperties
        /// <summary>
        /// Obtient l'identifiant de la destination
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Obtient la ville de la destination
        /// </summary>
        public string City { get => city; set => city = value; }

        /// <summary>
        /// Obtient le pays de la destination
        /// </summary>
        public string Country { get => country; set => country = value; }

        /// <summary>
        /// Obtient l'image de présentation de la destintation
        /// </summary>
        public string Image { get => image; set => image = value; }
        #endregion
    }
}