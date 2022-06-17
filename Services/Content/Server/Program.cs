using MassTransit;
using RunSynopsis.Application;
using RunSynopsis.Domain.Content.Database;
using RunSynopsis.Server;
using RunSynopsis.Server.Api;
using RunSynopsis.Server.Auth;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseDefaultServiceProvider(configure =>
{
    configure.ValidateScopes = true;
    configure.ValidateOnBuild = true;
});

var contentDbContextConfiguration = builder.Configuration
    .GetSection("Service:Content:Database")
    .Get<ContentDbContextConfig>();

builder.AddAuth();
builder.AddSearch();
builder.AddApi();

builder.Services.AddContentService(contentDbContextConfiguration);
builder.Services.AddTransient<IStartupFilter, MigrationsStartupFilter>();
builder.Services.AddMassTransitHostedService(true);

var app = builder.Build();
app.UseApi();
app.Run();