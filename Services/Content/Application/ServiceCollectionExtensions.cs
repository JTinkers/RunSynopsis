using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RunSynopsis.Application.Content.Ports;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Content;
using RunSynopsis.Domain.Content.Database;
using RunSynopsis.Domain.Content.Ports;
using System.Reflection;

namespace RunSynopsis.Application
{
    public static class ServiceCollectionExtensions
    {
        public static void AddContentService(this IServiceCollection services,
            ContentDbContextConfig contentDbContextConfig)
        {
            services
                .AddAutoMapper(typeof(ContentAutoMapperProfile))
                .AddScoped<IContentService, ContentService>()
                .AddScoped<IUserContext, UserContext>()
                .AddSingleton<ISlugifier, Slugifier>()
                .AddPooledDbContextFactory<ContentDbContext>(optionsBuilder =>
                {
                    optionsBuilder.UseLazyLoadingProxies();

                    optionsBuilder.UseNpgsql(contentDbContextConfig.ConnectionString!, 
                        config => config.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
                });
        }
    }
}