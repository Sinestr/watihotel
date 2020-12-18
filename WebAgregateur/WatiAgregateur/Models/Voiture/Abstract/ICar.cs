using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatiAgregateur.Models.Voiture.Abstract
{
    public interface ICar
    {
        #region Propoerties
        int Id { get ; set; }
        string Name { get ; set; }
        string Brand { get ; set; }
        string Description { get; set; }
        double Price { get; set; }
        #endregion
    }
}
