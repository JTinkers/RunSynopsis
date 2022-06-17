using HotChocolate.Resolvers;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Middleware
{
    public class AuthMiddleware
    {
        private readonly FieldDelegate _next;

        private readonly IUserContext _userContext;

        private readonly Permission? _requiredPermission;

        public AuthMiddleware(
            FieldDelegate next,
            IUserContext userContext,
            Permission? requiredPermission = null)
        {
            _next = next;
            _userContext = userContext;
            _requiredPermission = requiredPermission;
        }

        public async Task InvokeAsync(IMiddlewareContext context)
        {
            _userContext.Authorize(_requiredPermission);

            await _next.Invoke(context);
        }
    }
}