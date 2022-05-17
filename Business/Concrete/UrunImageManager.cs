using Business.Abstract;
using Core.Utilities.Helpers.FileHelper.Concrete;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UrunImageManager : IUrunImageService
    {
        IUrunImageDal _urunImageDal;
        IFileHelper _fileHelper;

        public UrunImageManager(IUrunImageDal urunImageDal,IFileHelper fileHelper)
        {
            _urunImageDal = urunImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file,UrunImage image)
        {
            var ımage=_fileHelper.Upload(file);
            if (ımage==null)
            {
                return new ErrorResult("resim alınamadı");
            }
            image.ImagePath = ımage.Message;
            image.Date=DateTime.Now;
            _urunImageDal.Add(image);
            return new SuccessResult("Yeni Resim EKlendi");
           
        }

        public IResult Delete(UrunImage image)
        {
            var result = _urunImageDal.Get(x => x.UrunId == image.UrunId);
            if (result == null)
            {
                return new ErrorResult("Image not found");
            }
            _fileHelper.Delete(result.ImagePath);
            _urunImageDal.Delete(image);
            return new SuccessResult("Image was deleted succesfully");

        }

        public IDataResult<UrunImage> Get(Expression<Func<UrunImage, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<UrunImage>> GetAll(Expression<Func<UrunImage, bool>> filter = null)
        {
            return new SuccessDataResult<List<UrunImage>>(_urunImageDal.GetAll());

        }

        public IResult Update(IFormFile file,UrunImage image)
        {
           var uploadfile=_fileHelper.Update(file,image.ImagePath);
            if (!uploadfile.Success)
            {
                return new ErrorResult("güncellenemedi");
            }
            image.ImagePath = uploadfile.Message;
            _urunImageDal.Update(image);
            return new SuccessResult("ürünlergüncellendi");
        }
    }
}
