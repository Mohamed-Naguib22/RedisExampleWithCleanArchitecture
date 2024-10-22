using RedisExampleWithCleanArchitecture.WebApi.Extensions;
using RedisExampleWithCleanArchitecture.WebApi.Middlewares;
using RedisExampleWithCleanArchitecture.Application.Extensions;
using RedisExampleWithCleanArchitecture.Persistence.Extensions;
using RedisExampleWithCleanArchitecture.Infrastructure.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpClient();

builder.Services.ConfigureInfrastructure(builder.Host, builder.Configuration);
builder.Services.ConfigurePersistence(builder.Configuration);
builder.Services.ConfigureApplication();
builder.Services.ConfigureSwagger(builder.Configuration);
builder.Services.ConfigureApiBehavior();
builder.Services.ConfigureCorsPolicy();
builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwaggerDevelopment(builder.Configuration, "SwaggerConfigTest");
}
else if (app.Environment.IsProduction())
{
    app.UseSwaggerProduction(builder.Configuration, "SwaggerConfigTest");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseErrorHandler();
app.UseCors();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseSeriLog();

try
{
    Log.Information("Starting up the web host");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}