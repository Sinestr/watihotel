using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatiAgregateur.Models.Voiture.Abstract
{
    public interface IReservation
    {
        #region Properties
        int Id { get; set; }
        int CarId { get; set; }
        DateTime DateStart { get; set; }
        DateTime DateEnd { get; set; }
        #endregion
    }
}
