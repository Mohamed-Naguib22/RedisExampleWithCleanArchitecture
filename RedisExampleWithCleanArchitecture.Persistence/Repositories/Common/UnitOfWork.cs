using RedisExampleWithCleanArchitecture.Application.IContract.IRepositories.ICommon;
using RedisExampleWithCleanArchitecture.Domain.Entities.Common;
using RedisExampleWithCleanArchitecture.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Persistence.Repositories.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicantionDbContext _context;

        public UnitOfWork(ApplicantionDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new BaseRepository<T>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
