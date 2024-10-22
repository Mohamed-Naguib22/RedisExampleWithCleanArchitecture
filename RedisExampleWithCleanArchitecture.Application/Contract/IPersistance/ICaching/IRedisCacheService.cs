using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Application.Contract.IPersistance.ICaching
{
    public interface IRedisCacheService
    {
        Task<T> GetDataAsync<T>(string key);
        Task SetDataAsync<T>(string key, T data);
    }
}
