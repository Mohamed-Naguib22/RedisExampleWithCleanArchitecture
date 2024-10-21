using Microsoft.EntityFrameworkCore;
using RedisExampleWithCleanArchitecture.Application.IContract.ICommon;
using RedisExampleWithCleanArchitecture.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Persistence.Services
{
    public static class SpecificationElevator<T> where T : BaseEntity
    {
        public static IQueryable<T> Elevate(IQueryable<T> inputQuery, IBaseSpecification<T> specification)
        {
            if (specification.Criteria is not null)
            {
                inputQuery = inputQuery.Where(specification.Criteria);
            }

            inputQuery = specification.IncludeExpressions.Aggregate(inputQuery,
                (current, includeExpression) =>
                    current.Include(includeExpression));

            if (specification.OrderByExpression is not null)
            {
                inputQuery = inputQuery.OrderBy(specification.OrderByExpression);
            }

            return inputQuery;
        }
    }
}
