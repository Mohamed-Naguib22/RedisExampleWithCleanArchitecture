﻿using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace RedisExampleWithCleanArchitecture.WebApi.Extensions
{
    public static class ApiBehaviorExtension
    {
        public static void ConfigureApiBehavior(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });
        }
    }
}
