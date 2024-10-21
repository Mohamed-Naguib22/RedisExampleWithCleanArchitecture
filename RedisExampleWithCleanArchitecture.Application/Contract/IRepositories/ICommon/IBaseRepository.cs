using Microsoft.EntityFrameworkCore.Query;
using RedisExampleWithCleanArchitecture.Application.IContract.ICommon;
using RedisExampleWithCleanArchitecture.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.IContract.IRepositories.ICommon
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task<T> AddAsyncWithReturn(T entity);
        Task AddRangeAsync(List<T> entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> FirstOrDefaultAsync(IBaseSpecification<T> specification);
        Task<IEnumerable<T>> FindAsync(IBaseSpecification<T> specification);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
