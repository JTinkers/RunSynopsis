using HotChocolate.Resolvers;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Middleware
{
    public class AuthMiddleware
    {
        private readonly FieldDelegate _next;

        private readonly IUserContext _userContext;

        private readonly Permission? _permission;

        public AuthMiddleware(FieldDelegate next,
            IUserContext userContext,
            Permission? permission = null)
        {
            _next = next;
            _userContext = userContext;
            _permission = permission;
        }

        public async Task InvokeAsync(IMiddlewareContext context)
        {
            _userContext.Authorize(_permission);

            await _next.Invoke(context);
        }
    }
}