using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace RedisExampleWithCleanArchitecture.WebApi.Filters
{
    public class AddAcceptLanguageHeaderParameterFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters ??= [];

            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Description = "Language of the request",
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            });
        }
    }
}
