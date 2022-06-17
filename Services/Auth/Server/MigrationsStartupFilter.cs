using Microsoft.EntityFrameworkCore;
using RunSynopsis.Domain.Auth.Database;

namespace RunSynopsis.Server
{
    public class MigrationsStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                using var scope = app.ApplicationServices
                    .CreateScope();

                scope.ServiceProvider
                    .GetRequiredService<IDbContextFactory<AuthDbContext>>()
                    .CreateDbContext()
                    .Database
                    .Migrate();

                next(app);
            };
        }
    }
}