using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Result;

using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userRepository)
        {
            _userDal = userRepository;
        }

        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return new SuccessDataResult<List<User>>(this._userDal.GetAll(filter), "Kullanıcılar listelendi");
        }
        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            return new SuccessDataResult<User>(this._userDal.Get(filter), "Kullanıcı getirildi");
        }
      
        public IResult Add(User user)
        {
            this._userDal.Add(user);
            return new SuccessResult("Kişi eklendi");
        }

        public IResult Delete(User user)
        {
            this._userDal.Delete(user);
            return new SuccessResult("Kişi silindi");
        }


        public IResult Update(User user)
        {
            this._userDal.Update(user);
            return new SuccessResult("Kişi güncellendi");
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}