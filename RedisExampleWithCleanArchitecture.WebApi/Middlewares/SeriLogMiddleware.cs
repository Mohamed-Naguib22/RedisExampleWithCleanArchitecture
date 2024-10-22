using Microsoft.Extensions.Options;
using Serilog;
using Serilog.Events;

namespace RedisExampleWithCleanArchitecture.WebApi.Middlewares
{
    public static class SeriLogMiddleware
    {
        public static void UseSeriLog(this IApplicationBuilder app)
        {
            app.UseSerilogRequestLogging(options =>
            {
                options.MessageTemplate = "Handled {RequestPath}";

                options.GetLevel = (httpContext, elapsed, ex) => elapsed > 1000
                    ? LogEventLevel.Warning
                    : LogEventLevel.Information;

                options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
                {
                    diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                    diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                    diagnosticContext.Set("RequestMethod", httpContext.Request.Method);
                    diagnosticContext.Set("RequestPath", httpContext.Request.Path);
                };
            });
        }
    }
}
