using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using RedisExampleWithCleanArchitecture.Application.Exceptions;

namespace RedisExampleWithCleanArchitecture.WebApi.Middlewares
{
    public static class ErrorHandlerMiddleWare
    {
        public static void UseErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature == null) return;

                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.ContentType = "application/json";

                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        BadRequestException => (int)HttpStatusCode.BadRequest,
                        OperationCanceledException => (int)HttpStatusCode.ServiceUnavailable,
                        NoDataFoundException => (int)HttpStatusCode.NotFound,
                        AlreadyExistsException => (int)HttpStatusCode.Conflict,
                        EntityNotFoundException => (int)HttpStatusCode.NotFound,
                        ErrorMappingException => (int)HttpStatusCode.InternalServerError,
                        SaveChangesFailedException => (int)HttpStatusCode.NotAcceptable,
                        SocketException => (int)HttpStatusCode.BadGateway,
                        UnValidatedAccessException => (int)HttpStatusCode.Unauthorized,
                        UnauthenticatedException => (int)HttpStatusCode.Forbidden,
                        InvalidOperationsException => (int)HttpStatusCode.Forbidden,
                        ValidationErrorException => (int)HttpStatusCode.BadRequest,
                        Application.Exceptions.UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                        _ => (int)HttpStatusCode.InternalServerError
                    };

                    var errorResponse = new
                    {
                        statusCode = context.Response.StatusCode,
                        message = contextFeature.Error.GetBaseException().Message,
                        Errors = contextFeature.Error switch
                        {
                            ValidationErrorException validationError => validationError.Errors,
                            BadRequestException badRequestError => badRequestError.Errors,
                            _ => null
                        }

                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
                });
            });
        }
    }
}
