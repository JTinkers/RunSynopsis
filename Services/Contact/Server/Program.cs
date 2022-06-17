using MassTransit;
using RunSynopsis.Application;
using RunSynopsis.Application.Contact.Ports;
using RunSynopsis.Server.Api;
using RunSynopsis.Server.Auth;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseDefaultServiceProvider(configure =>
{
    configure.ValidateScopes = true;
    configure.ValidateOnBuild = true;
});

var contactCacheConfiguration = builder.Configuration
    .GetSection("Service:Cache")
    .Get<ContactCacheConfiguration>();

builder.AddApi();
builder.AddAuth();

builder.Services.AddContactService(contactCacheConfiguration);
builder.Services.AddMassTransitHostedService(true);

var app = builder.Build();
app.UseApi();
app.Run();