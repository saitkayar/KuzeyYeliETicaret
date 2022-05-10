using Core.Utilities.Result;
using Entities.Concrete;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IMusteriService
    {
        IDataResult<List<Musteri>> GetAll(Expression<Func<Musteri,bool>> filter=null);
        IDataResult<Musteri> Get(Expression<Func<Musteri,bool>> filter);
    }
}
