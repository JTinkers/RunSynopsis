using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RunSynopsis.Server.Api;
using RunSynopsis.Server.Auth;
using RunSynopsis.Server.Auth.Entities;

namespace RunSynopsis.Server.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(
            HttpContext context,
            IAuthService service,
            IOptions<ApiConfiguration> configuration)
        {
            var cookies = context.Request.Cookies;
            var headers = context.Request.Headers;

            var cookieName = configuration.Value
                .Auth
                .TokenCookieName;

            string? token = null;
            User? user = null;

            if (cookies.ContainsKey(cookieName))
                token = cookies[cookieName]!;

            if (!string.IsNullOrEmpty(token))
                user = await service.GetUserByTokenAsync(TokenType.Session, token);

            // log out if user expired or token leads to invalid user
            headers.Authorization = user is not null
                ? JsonConvert.SerializeObject(user)
                : null;

            await _next.Invoke(context);
        }
    }
}