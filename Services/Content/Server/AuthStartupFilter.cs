using RunSynopsis.Domain.Content.Entities;
using RunSynopsis.Server.Auth;

namespace RunSynopsis.Server
{
    public class AuthStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                using var scope = app.ApplicationServices
                    .CreateScope();

                var service = scope.ServiceProvider
                    .GetRequiredService<IAuthService>();

                foreach (var value in Enum.GetValues<ContentPermission>())
                    service.StorePermissionAsync(value);

                next(app);
            };
        }
    }
}