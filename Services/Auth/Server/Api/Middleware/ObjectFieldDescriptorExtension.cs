using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Middleware
{
    public static class ObjectFieldDescriptorExtension
    {
        public static void UseAuth<TEnum>(this IObjectFieldDescriptor descriptor,
            TEnum requiredPermission) where TEnum : Enum
        {
            var permission = requiredPermission is not null
                ? new Permission(requiredPermission.GetType().Name, requiredPermission.ToString())
                : null;

            descriptor.Use((_, next) => new AuthMiddleware(next, permission));
        }

        public static void UseAuth(this IObjectFieldDescriptor descriptor)
        {
            descriptor.Use((_, next) => new AuthMiddleware(next));
        }
    }
}