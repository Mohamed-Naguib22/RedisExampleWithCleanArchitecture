using Microsoft.EntityFrameworkCore;
using RedisExampleWithCleanArchitecture.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Contract.IPersistance.IRepositories.ICommon
{
    public interface IUnitOfWork
    {
        IBaseRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChangesAsync();
    }
}
