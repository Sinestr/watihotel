using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WatiHotel.Models
{
    public class Response
    {
        string type;
        string message;

        public Response(string uneError, string unMessage)
        {
            this.Type = uneError;
            this.Message = unMessage;
        }

        public string Type { get => type; set => type = value; }
        public string Message { get => message; set => message = value; }
    }
}