using MassTransit;
using Microsoft.AspNetCore.Http.Features;
using RunSynopsis.Application;
using RunSynopsis.Application.Storage.Ports.Configuration;
using RunSynopsis.Server;
using RunSynopsis.Server.Api;
using RunSynopsis.Server.Auth;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseDefaultServiceProvider(configure =>
{
    configure.ValidateScopes = true;
    configure.ValidateOnBuild = true;
});

var registryConfiguration = builder.Configuration
    .GetSection("Service:Media:Registry")
    .Get<MediaRegistryConfiguration>();

var streamRepositoryConfiguration = builder.Configuration
    .GetSection("Service:Media:StreamRepository")
    .Get<MediaStreamRepositoryConfiguration>();

builder.AddAuth();
builder.AddApi();

builder.Services.AddStorageService(registryConfiguration, streamRepositoryConfiguration);
builder.Services.AddMassTransitHostedService(true);

var serverConfiguration = builder.Configuration
    .GetSection("Server")
    .Get<ServerConfiguration>();

builder.Services.Configure<FormOptions>(options
    => options.MultipartBodyLengthLimit = serverConfiguration.MaxUploadFileSize);

var app = builder.Build();
app.UseApi();
app.Run();