using Microsoft.Extensions.DependencyInjection;
using RunSynopsis.Application.Mailing.Ports;
using RunSynopsis.Application.Mailing.Ports.Configuration;
using RunSynopsis.Domain.Mailing;
using RunSynopsis.Domain.Mailing.Ports;
using StackExchange.Redis;

namespace RunSynopsis.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMailingService(this IServiceCollection services,
            MailSenderConfiguration mailSenderConfiguration,
            NewsletterCacheConfiguration newsletterCacheConfiguration)
        {
            services.AddSingleton(mailSenderConfiguration);
            services.AddSingleton(newsletterCacheConfiguration);
            services.AddScoped<IMailingService, MailingService>();
            services.AddScoped<IMailSender, MailSender>();
            services.AddScoped<INewsletterService, NewsletterService>();
            services.AddScoped<INewsletterCache, NewsletterCache>();

            services
                .AddFluentEmail(
                    mailSenderConfiguration.FromAddress, 
                    mailSenderConfiguration.From
                )
                .AddSmtpSender(
                    mailSenderConfiguration.Host, 
                    mailSenderConfiguration.Port
                );

            var redisOptions = new ConfigurationOptions
            {
                AbortOnConnectFail = false,
                EndPoints = { "rsmailing-redis" }
            };

            services.AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(redisOptions));
        }
    }
}