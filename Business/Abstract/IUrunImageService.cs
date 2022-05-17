using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUrunImageService
    {
        IDataResult<List<UrunImage>> GetAll(Expression<Func<UrunImage, bool>> filter = null);
        IDataResult<UrunImage> Get(Expression<Func<UrunImage, bool>> filter );
        IResult Add(IFormFile file, UrunImage image);
        IResult Delete(UrunImage image);
        IResult Update(IFormFile file, UrunImage image);
    }
}
