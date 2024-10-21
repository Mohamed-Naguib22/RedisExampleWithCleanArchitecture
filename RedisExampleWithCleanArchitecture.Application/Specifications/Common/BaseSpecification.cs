using RedisExampleWithCleanArchitecture.Application.IContract.ICommon;
using RedisExampleWithCleanArchitecture.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Specifications.Common
{
    public abstract class BaseSpecification<T> : IBaseSpecification<T> where T : BaseEntity
    {
        protected BaseSpecification(Expression<Func<T, bool>>? criteria = null)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>>? Criteria { get; }
        public List<Expression<Func<T, object>>> IncludeExpressions { get; } = new();
        public Expression<Func<T, object>>? OrderByExpression { get; private set; }
        protected void AddIclude(Expression<Func<T, object>> includeExpression) =>
            IncludeExpressions.Add(includeExpression);
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression) =>
           OrderByExpression = orderByExpression;
    }
}
