using HotChocolate.AspNetCore;
using HotChocolate.Execution;
using Newtonsoft.Json;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Interceptors
{
    internal class AuthRequestInterceptor : DefaultHttpRequestInterceptor
    {
        public override ValueTask OnCreateAsync(
            HttpContext context,
            IRequestExecutor requestExecutor,
            IQueryRequestBuilder requestBuilder,
            CancellationToken cancellationToken)
        {
            var userContext = context.RequestServices.GetRequiredService<IUserContext>();

            userContext.SetUser(null);

            var header = context.Request.Headers.Authorization.ToString();

            if (!string.IsNullOrEmpty(header))
            {
                var user = JsonConvert.DeserializeObject<User>(header);

                userContext.SetUser(user);
            }

            return base.OnCreateAsync(context, requestExecutor, requestBuilder, cancellationToken);
        }
    }
}