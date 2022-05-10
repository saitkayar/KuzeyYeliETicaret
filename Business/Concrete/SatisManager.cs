using Business.Abstract;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SatisManager : ISatisService
    {
        private readonly ISatisDal _satisDal;

        public SatisManager(ISatisDal satisDal)
        {
            _satisDal = satisDal;
        }

        public IDataResult<Satis> Get(Expression<Func<Satis, bool>> filter)
        {
            return new SuccessDataResult<Satis>(_satisDal.Get(filter),"Ürün getirildi");
        }

        public IDataResult<List<Satis>> GetAll(Expression<Func<Satis, bool>> filter = null)
        {
            return new SuccessDataResult<List<Satis>>(_satisDal.GetAll(filter));
        }
    }
}
