using Microsoft.EntityFrameworkCore.Query;
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
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(Guid id);
        Task AddAsync(T entity);
        Task<T> AddAsyncWithReturn(T entity);
        Task AddRangeAsync(List<T> entity);
        void Update(T entity);
        void Delete(T entity);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            int? take = null,
            Expression<Func<T, object>>? orderBy = null,
            Expression<Func<T, object>>? thenOrderBy = null,
            bool orderByDescending = false);
        Task<(int, List<T>)> FindWithPaginationAsync(Expression<Func<T, bool>> predicate,
            int pageNumber, int pageSize,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Expression<Func<T, object>>? orderBy = null, bool orderByDescending = false);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Expression<Func<T, object>>? orderBy = null,
            Expression<Func<T, object>>? thenOrderBy = null,
            bool orderByDescending = false);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    }
}
