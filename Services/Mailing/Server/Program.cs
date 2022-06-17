using MassTransit;
using RunSynopsis.Application;
using RunSynopsis.Application.Mailing.Ports.Configuration;
using RunSynopsis.Server.Api;
using RunSynopsis.Server.Bus;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseDefaultServiceProvider(configure =>
{
    configure.ValidateScopes = true;
    configure.ValidateOnBuild = true;
});

var mailSenderConfiguration = builder.Configuration
    .GetSection("Service:MailSender")
    .Get<MailSenderConfiguration>();

var newsletterCacheConfiguration = builder.Configuration
    .GetSection("Service:Newsletter:Cache")
    .Get<NewsletterCacheConfiguration>();

builder.AddBus();
builder.AddApi();

builder.Services.AddMailingService(mailSenderConfiguration, newsletterCacheConfiguration);
builder.Services.AddMassTransitHostedService(true);

var app = builder.Build();
app.UseApi();
app.Run();