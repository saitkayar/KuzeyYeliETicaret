using Core.Entities.Concrete;
using Core.Utilities.Result;
using System.Linq.Expressions;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByMail(string email);
    }
}
