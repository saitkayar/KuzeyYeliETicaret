using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class UrunDal : EfEntityBaseRepositoryBase<Urun, KuzeyYeliDBContext>, IUrunDal
    {
        public List<UrunDto> GetUrunDetay()
        {
            using (var context=new KuzeyYeliDBContext())
            {
                var result = from u in context.Urunler
                             join k in context.Kategoriler
                             on u.KategoriID equals k.KategoriID
                             select new UrunDto
                             {
                                 UrunID = u.UrunID,
                                 Stok = u.Stok,
                                 Fiyat = u.Fiyat,
                                 KAtegoriAdi = k.KAtegoriAdi,
                                 UrunAdi = u.UrunAdi,
                             };
                return result.ToList();
            }
        }
    }
}
