using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISatisService
    {
        IDataResult<List<Satis>> GetAll(Expression<Func<Satis, bool>> filter=null);
        IDataResult<Satis> Get(Expression<Func<Satis, bool>> filter);
    }
}
