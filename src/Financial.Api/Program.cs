using Financial.Api.Extensions;
using Financial.Api.Services;
using Financial.Application;
using Financial.Persistence;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddApi();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Financial Api v1");
        options.RoutePrefix = "swagger";
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapApiEndpoint();

var startupLogger = app.Services
    .GetRequiredService<ILoggerFactory>()
    .CreateLogger("Financial.Api.Startup");

app.Lifetime.ApplicationStarted.Register(() =>
{
    var addresses = app.Urls;

    if (addresses.Count == 0)
    {
        var serverAddresses = app.Services
            .GetRequiredService<IServer>()
            .Features
            .Get<IServerAddressesFeature>();

        if (serverAddresses is not null)
            addresses = serverAddresses.Addresses;
    }

    foreach (var address in addresses)
    {
        startupLogger.LogInformation("Swagger UI available at {SwaggerUrl}", $"{address.TrimEnd('/')}/swagger");
        startupLogger.LogInformation("OpenAPI JSON available at {OpenApiUrl}", $"{address.TrimEnd('/')}/openapi/v1.json");
    }
});

app.Run();
