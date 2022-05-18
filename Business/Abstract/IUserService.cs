using Core.Entities.Concrete;
using Core.Utilities.Result;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IUserService
    {
        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null);
        public IDataResult<User> Get(Expression<Func<User, bool>> filter);
        public IResult Add(User user);
        public IResult Update(User user);
        public IResult Delete(User user);
        public List<OperationClaim> GetClaims(User user);

    }
}
