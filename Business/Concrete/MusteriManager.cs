using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Concrete
{
    public class MusteriManager : IMusteriService
    {
        private readonly IMusteriDal _musteriDal;

        public MusteriManager(IMusteriDal musteriDal)
        {
            _musteriDal = musteriDal;
        }

        public IDataResult<Musteri> Get(Expression<Func<Musteri, bool>> filter)
        {
            return new SuccessDataResult<Musteri>(_musteriDal.Get(filter), "Müşteri GEtirildi");
        }

        public IDataResult<List<Musteri>> GetAll(Expression<Func<Musteri, bool>> filter = null)
        {
            return new SuccessDataResult<List<Musteri>>(_musteriDal.GetAll(filter), "Müşteriler getirildi");

        }
    }
}
