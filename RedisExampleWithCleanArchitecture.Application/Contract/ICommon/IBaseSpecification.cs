using RedisExampleWithCleanArchitecture.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.IContract.ICommon
{
    public interface IBaseSpecification<T> where T : BaseEntity
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> IncludeExpressions { get; }
        Expression<Func<T, object>>? OrderByExpression { get; }
    }
}
