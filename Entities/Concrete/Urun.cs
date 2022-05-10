using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Urun: IEntity
    {
        public int UrunID { get; set; }
        public int KategoriID { get; set; }
        public string UrunAdi { get; set; }
        public short Stok { get; set; }
        public decimal Fiyat { get; set; }
    }
}
