using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class KategoriManager : IKategoriService
    {
        private IKategoriDal _kategoriDal;

        public KategoriManager(IKategoriDal kategoriDal)
        {
            _kategoriDal = kategoriDal;
        }

        public IDataResult<Kategori> Get(Expression<Func<Kategori, bool>> filter)
        {
            return new SuccessDataResult<Kategori>(_kategoriDal.Get(filter), "Kategori geldi");
        }

        public IDataResult<List<Kategori>> GetAll(Expression<Func<Kategori, bool>> filter = null)
        {
            return new SuccessDataResult<List<Kategori>>(_kategoriDal.GetAll(filter), "Tüm Kategoriler");
        }
    }
}
