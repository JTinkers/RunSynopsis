using MassTransit;
using RunSynopsis.Application;
using RunSynopsis.Application.Auth.Ports.Configuration;
using RunSynopsis.Domain.Auth.Database;
using RunSynopsis.Server;
using RunSynopsis.Server.Api;
using RunSynopsis.Server.Bus;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseDefaultServiceProvider(configure =>
{
    configure.ValidateScopes = true;
    configure.ValidateOnBuild = true;
});

var tokenizerConfiguration = builder.Configuration
    .GetSection("Service:Auth:Tokenizer")
    .Get<TokenizerConfiguration>();

var authDbContextConfiguration = builder.Configuration
    .GetSection("Service:Auth:Database")
    .Get<AuthDbContextConfig>();

builder.AddApi();
builder.AddBus();

builder.Services.AddAuthService(tokenizerConfiguration, authDbContextConfiguration);
builder.Services.AddTransient<IStartupFilter, MigrationsStartupFilter>();
builder.Services.AddTransient<IStartupFilter, AuthStartupFilter>();
builder.Services.AddMassTransitHostedService(true);

var app = builder.Build();
app.UseApi();
app.Run();