using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(UrunValidator))]
        public IResult Add(Urun urun)
        {
          IResult result=  BusinessRules.Run(CheckUrunName(urun.UrunAdi));

            if (result!=null)
            {
                return result;
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
        [ValidationAspect(typeof(UrunValidator))]
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

        private IResult CheckUrunName(string name)
        {
            Urun urun = _urunDal.Get(u => u.UrunAdi == name);
            if (urun!=null)
            {
                return new ErrorResult("bu isimde ürün zaten mevcut");
            }
            return new SuccessResult();
        }
    }
}
