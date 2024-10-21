using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisExampleWithCleanArchitecture.Infrastructure.Extensions
{
    public static class ServicesRegisterationExtension
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IHostBuilder host, IConfiguration configuration)
        {
            host.UseSerilog();
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
        }
    }
}
