using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class UrunDto:IDto
    {
        public int UrunID { get; set; }
        public string UrunAdi { get; set; }
        public short Stok { get; set; }
        public decimal Fiyat { get; set; }
        public string KategoriAdi { get; set; }
    }
}
