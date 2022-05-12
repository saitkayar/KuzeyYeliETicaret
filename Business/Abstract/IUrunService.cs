using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUrunService

    {
        IDataResult<List<Urun>> GetAll();
        IDataResult<List<Urun>> GetAllByKategoriId(int id);
        IDataResult<List<Urun>> GetAllByFiyat(decimal min, decimal max);
        IDataResult<List<UrunDto>> GetAllByDetay();
      IDataResult<Urun> GetById(int id);

        IResult Add(Urun urun);
        IResult Delete(Urun urun);
        IResult Update(Urun urun);

    }
}
