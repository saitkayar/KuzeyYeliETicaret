using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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

        [ValidationAspect(typeof(KategoriValidator))]
        public IResult Add(Kategori kategori)
        {
         IResult result=   BusinessRules.Run(CheckKategoriName(kategori.KategoriAdi));
            if (result!=null)
            {
                return result;
            }
            _kategoriDal.Add(kategori);
            return new SuccessResult("yeni kategori eklendi");
        }

        public IResult Delete(Kategori kategori)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Kategori> Get(Expression<Func<Kategori, bool>> filter)
        {
            return new SuccessDataResult<Kategori>(_kategoriDal.Get(filter), "Kategori geldi");
        }

        public IDataResult<List<Kategori>> GetAll(Expression<Func<Kategori, bool>> filter = null)
        {
            return new SuccessDataResult<List<Kategori>>(_kategoriDal.GetAll(filter), "Tüm Kategoriler");
        }

        public IResult Update(Kategori kategori)
        {
            throw new NotImplementedException();
        }

        public IResult CheckKategoriName(string name)
        {
            Kategori kategori = _kategoriDal.Get(k => k.KategoriAdi == name);
            if (kategori != null)
            {
                return new SuccessResult("Aynı isimde kategori olmaz");
            }
            return new SuccessResult();
        }
    }
}
