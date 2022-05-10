using Business.Abstract;
using Business.Constants;
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
         var resukt=   _urunDal.GetAll().ToList();
            return new SuccessDataResult<List<Urun>>(resukt); 
        }

        public IDataResult<List<Urun>> GetAllByDetay()
        {
          _urunDal.GetUrunDetay();
            return new SuccessDataResult<List<Urun>>();
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
            _urunDal.Get(u => u.UrunID == id);
         return new SuccessDataResult<Urun>();
        }
    }
}
