using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WatiHotel.Models
{
    [DataContract]
    [JsonObject(MemberSerialization.OptOut)]
    public class Disponible
    {
        /// <summary>
        /// 
        /// </summary>
        private int _Room_available;

        /// <summary>
        /// 
        /// </summary>
        private DateTime _Date_Room;

        /// <summary>
        /// 
        /// </summary>
        public int Room_available { get => _Room_available; set => _Room_available = value; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Date_Room { get => _Date_Room; set => _Date_Room = value; }



    }
}