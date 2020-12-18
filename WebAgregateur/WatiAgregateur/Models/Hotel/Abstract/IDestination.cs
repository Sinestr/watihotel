using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatiAgregateur.Models.Hotel.Abstract
{
    public interface IDestination
    {
        int Id { get; set; }

        string City { get; set; }

        string Country { get; set; }
    }
}
