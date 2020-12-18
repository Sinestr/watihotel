using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatiAgregateur.Models.Hotel.Abstract
{
    public interface IReservation
    {
        int Id { get; set; }
        DateTime DateStart { get; set; }
        DateTime DateEnd { get; set; }
        int Hotel { get; set; }
        bool Status { get; set; }
    }
}
