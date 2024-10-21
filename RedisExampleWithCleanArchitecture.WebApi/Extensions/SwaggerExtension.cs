using Microsoft.OpenApi.Models;
using RedisExampleWithCleanArchitecture.WebApi.Filters;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace RedisExampleWithCleanArchitecture.WebApi.Extensions
{
    public static class SwaggerExtension
    {
        public static void ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            var TestToken = configuration.GetSection("AppSettings:TestToken").Value;

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "RedisExampleWithCleanArchitecture API", Version = "v1" });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = TestToken,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }

                });

                options.OperationFilter<AddAcceptLanguageHeaderParameterFilter>();
            });
        }

        public static void UseSwaggerProduction(this IApplicationBuilder app, IConfiguration configuration, string SwaggerConfigName)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "RedisExampleWithCleanArchitecture API v1");
                c.RoutePrefix = string.Empty;
                string endPoint = configuration[$"{SwaggerConfigName}:EndPoint"];
                string title = configuration[$"{SwaggerConfigName}:Title"];
                c.SwaggerEndpoint(endPoint, title);
                c.DocumentTitle = $"{title} Documentation";
                c.DocExpansion(DocExpansion.None);
            });
        }

        public static void UseSwaggerDevelopment(this IApplicationBuilder app, IConfiguration configuration, string SwaggerConfigName)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                string endPoint = configuration[$"{SwaggerConfigName}:EndPoint"];
                string title = configuration[$"{SwaggerConfigName}:Title"];
                c.SwaggerEndpoint(endPoint, title);
                c.DocumentTitle = $"{title} Documentation";
                c.DocExpansion(DocExpansion.None);
            });
        }
    }
}
