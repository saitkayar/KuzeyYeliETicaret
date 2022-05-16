using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UrunManager : IUrunService
    {
        private IUrunDal _urunDal;

        public UrunManager(IUrunDal urunDal)
        {
            _urunDal = urunDal;
        }
        [ValidationAspect(typeof(UrunValidator))]
        public IResult Add(Urun urun)
        {
            if (urun.UrunAdi.Length < 2)
            {
                return new ErrorResult(Messages.UrunNameInvalıd);
            }
            _urunDal.Add(urun);
            return new SuccessResult(Messages.UrunAdded);
        }

        public IResult Delete(Urun urun)
        {
            _urunDal.Delete(urun);
            return new SuccessResult();
        }

        public IDataResult<List<Urun>> GetAll()
        {
        //    if (DateTime.Now.Hour==16)
        //    {
        //        return new SuccessDataResult<List<Urun>>("sistem bakımda");

        //    }
            var resukt=   _urunDal.GetAll().ToList();
            return new SuccessDataResult<List<Urun>>(resukt); 
        }

        public IDataResult<List<UrunDto>> GetAllByDetay()
        {
         var result= _urunDal.GetUrunDetay();
            return new SuccessDataResult<List<UrunDto>>(result);
        }

        public IDataResult<List<Urun>> GetAllByKategoriId(int id)
        {
         _urunDal.GetAll(u=>u.KategoriID == id);
            return new SuccessDataResult<List<Urun>>();
        }

        public IDataResult<List<Urun>> GetAllByFiyat(decimal min, decimal max)
        {
            
            return new SuccessDataResult<List<Urun>>();
        }

        public IResult Update(Urun urun)
        {
          
            _urunDal.Update(urun);
            return new SuccessResult("Urun güncellendi");
        }

        public IDataResult<Urun> GetById(int id)
        {
          var result=  _urunDal.Get(u => u.UrunID == id);
         return new SuccessDataResult<Urun>(result);
        }
    }
}
