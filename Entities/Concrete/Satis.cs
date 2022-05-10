using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Satis:IEntity
    {
        public int SatisID { get; set; }
        public string   MusteriID { get; set; }
        public DateTime SatisTarihi { get; set; }
        public string SevkSehri { get; set; }
        public int PersonelID { get; set; }
    }
}
