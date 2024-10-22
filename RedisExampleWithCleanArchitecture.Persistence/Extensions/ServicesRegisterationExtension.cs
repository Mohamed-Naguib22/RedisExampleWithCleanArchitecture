using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisExampleWithCleanArchitecture.Application.Contract.IPersistance.ICaching;
using RedisExampleWithCleanArchitecture.Application.Contract.IPersistance.IRepositories.ICommon;
using RedisExampleWithCleanArchitecture.Persistence.Caching;
using RedisExampleWithCleanArchitecture.Persistence.Context;
using RedisExampleWithCleanArchitecture.Persistence.Repositories.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Persistence.Extensions
{
    public static class ServicesRegisterationExtension
    {
        public static void ConfigurePersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicantionDbContext>(options => options.UseSqlServer(connection));

            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = configuration.GetConnectionString("Redis");
                options.InstanceName = "Products_";
            });

            services.AddScoped<IRedisCacheService, RedisCacheService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
