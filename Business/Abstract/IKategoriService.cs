using Core.Utilities.Result;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IKategoriService
    {
      IDataResult<List<Kategori>> GetAll(Expression<Func<Kategori,bool>> filter=null);
      IDataResult<Kategori> Get(Expression<Func<Kategori,bool>> filter);

        IResult Add(Kategori kategori);
        IResult Delete(Kategori kategori);
        IResult Update(Kategori kategori);

        
    }
}
