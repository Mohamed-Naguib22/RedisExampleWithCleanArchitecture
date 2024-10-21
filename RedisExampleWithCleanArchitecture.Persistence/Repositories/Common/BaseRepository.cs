using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RedisExampleWithCleanArchitecture.Domain.Entities.Common;
using RedisExampleWithCleanArchitecture.Persistence.Context;
using RedisExampleWithCleanArchitecture.Application.IContract.IRepositories.ICommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RedisExampleWithCleanArchitecture.Application.IContract.ICommon;
using RedisExampleWithCleanArchitecture.Persistence.Services;

namespace RedisExampleWithCleanArchitecture.Persistence.Repositories.Common
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly ApplicantionDbContext _context;
        private readonly DbSet<T> Entities;

        public BaseRepository(ApplicantionDbContext context)
        {
            _context = context;
            Entities = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var query = Entities.AsQueryable().AsNoTracking();
            return await query.Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            var query = Entities.AsQueryable();
            return await query.Where(predicate).ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await Entities.AddAsync(entity);
        }

        public async Task<T> AddAsyncWithReturn(T entity)
        {
            await Entities.AddAsync(entity);

            return entity;
        }

        public async Task AddRangeAsync(List<T> entity)
        {
            await Entities.AddRangeAsync(entity);
        }

        public void Update(T entity)
        {
            entity.DateUpdated = DateTimeOffset.UtcNow;
            Entities.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            Entities.Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            Entities.Remove(entity);
        }

        public async Task<T> FirstOrDefaultAsync(IBaseSpecification<T> specification)
        {
            var query = Entities.AsQueryable();
            query = SpecificationElevator<T>.Elevate(query, specification);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(IBaseSpecification<T> specification)
        {
            var query = Entities.AsQueryable().AsNoTracking();
            query = SpecificationElevator<T>.Elevate(query, specification);

            return await query.ToListAsync();
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            var query = Entities.AsQueryable();
            return await query.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
        {
            var query = Entities.AsQueryable();
            return await query.CountAsync(predicate);
        }
    }
}
