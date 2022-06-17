using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Auth.Entities;

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

                service.StorePermissionsAsync(Enum.GetValues<AuthPermission>());

                next(app);
            };
        }
    }
}