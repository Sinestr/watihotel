using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatiAgregateur.Models.Hotel.Abstract
{
    public interface IHotel
    {
        int Id { get; set; }

        string Name { get; set; }

        object Descritpion { get; set; }

        string Address { get; set; }

        double Price { get; set; }

        int RoomMax { get; set; }

        int Destination { get; set; }

        object Disponibilites { get; set; }
    }
}
