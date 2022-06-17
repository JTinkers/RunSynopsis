using HotChocolate.Resolvers;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Middleware
{
    public class AuthMiddleware
    {
        private readonly FieldDelegate _next;

        private readonly Permission? _permission;

        public AuthMiddleware(
            FieldDelegate next,
            Permission? permission = null)
        {
            _next = next;
            _permission = permission;
        }

        public async Task InvokeAsync(IUserContext userContext, IMiddlewareContext context)
        {
            userContext.Authorize(_permission);

            await _next.Invoke(context);
        }
    }
}