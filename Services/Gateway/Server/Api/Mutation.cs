using Microsoft.Extensions.Options;
using RunSynopsis.Server.Auth;

namespace RunSynopsis.Server.Api
{
    public class Mutation
    {
        private readonly ApiConfiguration _configuration;

        public Mutation(IOptions<ApiConfiguration> configuration)
        {
            _configuration = configuration.Value;
        }

        public async Task<bool> SignInAsync(
            IAuthService authService,
            IHttpContextAccessor accessor,
            string username,
            string password)
        {
            var context = accessor.HttpContext!;
            var cookies = context.Response.Cookies;

            var cookieName = _configuration
                .Auth
                .TokenCookieName;

            var token = (await authService.SignInAsync(username, password))!;

            cookies.Append(
                cookieName,
                token.Value,
                GetTokenCookieOptions());

            return true;
        }

        public async Task<bool> SignOutAsync(IHttpContextAccessor accessor)
        {
            var context = accessor.HttpContext!;
            var cookies = context.Response.Cookies;

            var cookieName = _configuration
                .Auth
                .TokenCookieName;

            cookies.Delete(cookieName, GetTokenCookieOptions());

            return await Task.FromResult(true);
        }

        private CookieOptions GetTokenCookieOptions()
        {
            var maxAge = TimeSpan.FromSeconds(_configuration.Auth.TokenTimespan);

            return new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.None, // fix this with reverse proxy
                MaxAge = maxAge,
                IsEssential = true,
            };
        }
    }
}