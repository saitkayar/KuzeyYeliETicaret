using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Musteri:IEntity
    {
        public string MusteriID { get; set; }
        public string MusteriAdi { get; set; }
        public string SirketAdi { get; set; }
        public string Sehir { get; set; }

    }
}
