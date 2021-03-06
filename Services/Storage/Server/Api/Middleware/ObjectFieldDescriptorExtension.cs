using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Middleware
{
    public static class ObjectFieldDescriptorExtension
    {
        public static void UseAuth<TEnum>(this IObjectFieldDescriptor descriptor,
            TEnum requiredPermission) where TEnum : Enum
        {
            var type = requiredPermission.GetType().Name;
            var value = requiredPermission.ToString();

            var permission = requiredPermission is not null
                ? new Permission(type, value)
                : null;

            descriptor.Use((services, next) => new AuthMiddleware(next,
                services.GetRequiredService<IUserContext>(), permission));
        }

        public static void UseAuth(this IObjectFieldDescriptor descriptor)
        {
            descriptor.Use((services, next) => new AuthMiddleware(next,
                services.GetRequiredService<IUserContext>()));
        }
    }
}