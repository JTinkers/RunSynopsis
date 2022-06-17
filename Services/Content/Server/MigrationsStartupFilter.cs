using Microsoft.EntityFrameworkCore;
using RunSynopsis.Domain.Content.Database;

namespace RunSynopsis.Server
{
    public class MigrationsStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                using var scope = app.ApplicationServices.CreateScope();

                scope.ServiceProvider
                    .GetRequiredService<IDbContextFactory<ContentDbContext>>()
                    .CreateDbContext()
                    .Database
                    .Migrate();

                next(app);
            };
        }
    }
}