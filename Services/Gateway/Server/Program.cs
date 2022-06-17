using MassTransit;
using RunSynopsis.Server.Api;
using RunSynopsis.Server.Auth;
using RunSynopsis.Server.Bus;
using RunSynopsis.Server.Monitoring;
using RunSynopsis.Server.Throttling;
using RunSynopsis.Server.Tracking;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseDefaultServiceProvider(configure =>
{
    configure.ValidateScopes = true;
    configure.ValidateOnBuild = true;
});

builder.AddTracking();
builder.AddThrottling();
builder.AddAuth();
builder.AddApi();
builder.AddServiceHealth();
builder.AddBus();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "app",
        builder =>
        {
            builder
                .WithOrigins(
                    "http://localhost:8080",
                    "https://localhost:8080",
                    "http://192.168.31.57:8080",
                    "https://192.168.31.57:8080",
                    "http://localhost:8070",
                    "https://localhost:8070",
                    "http://192.168.31.57:8070",
                    "https://192.168.31.57:8070"
                )
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
});

builder.Services.AddMassTransitHostedService(true);

var app = builder.Build();
app.UseCors("app");
app.UseTracking();
app.UseThrottling();
app.UseAuth();
app.UseApi();
app.Run();