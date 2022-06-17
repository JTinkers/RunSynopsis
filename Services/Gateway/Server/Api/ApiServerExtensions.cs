using HotChocolate.AspNetCore;
using RunSynopsis.Server.Api.Descriptors;
using RunSynopsis.Server.Auth;
using RunSynopsis.Server.Monitoring;
using StackExchange.Redis;

namespace RunSynopsis.Server.Api
{
    public static class ApiServerExtensions
    {
        /// <summary>
        /// Register and configure services used by the Api layer
        /// </summary>
        /// <param name="builder">WebApp builder to attach to</param>
        public static void AddApi(this WebApplicationBuilder builder)
        {
            builder.Services.AddOptions();
            builder.Services.AddHttpContextAccessor();

            builder.Services.Configure<ApiConfiguration>(builder.Configuration
                .GetSection("Server:Api"));

            builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer
                .Connect("rsgateway-redis"));

            builder.Services.AddHeaderPropagation(options
                => options.Headers.Add("Authorization"));

            var requestExecutorBuilder = builder.Services
                .AddGraphQLServer()
                .ModifyOptions(x =>
                {
                    x.SortFieldsByName = true;
                    x.ValidatePipelineOrder = true;
                })
                .ModifyRequestOptions(x =>
                {
                    x.IncludeExceptionDetails = builder.Environment.IsDevelopment();
                    x.ExecutionTimeout = TimeSpan.FromSeconds(60);
                    x.Complexity.Enable = true;
                    x.Complexity.DefaultComplexity = 1;
                    x.Complexity.DefaultResolverComplexity = 5;
                    x.Complexity.MaximumAllowed = 100;
                    x.Complexity.ApplyDefaults = true;
                    x.Complexity.ContextDataKey = "RequestComplexity";
                })
                .RegisterService<IAuthService>(ServiceKind.Resolver)
                .RegisterService<IServiceHealthService>(ServiceKind.Resolver)
                .RegisterService<IHttpContextAccessor>(ServiceKind.Resolver)
                .AddTypeExtension<QueryType>()
                .AddTypeExtension<MutationType>()
                .AddType<ServiceHealthType>();

            var addStitchingSource = (ApiStitchingSourceConfiguration source) =>
            {
                builder.Services
                    .AddHttpClient(source.Name, client => client.BaseAddress = source.Uri)
                    .AddHeaderPropagation(options => options.Headers.Add("Authorization"));

                requestExecutorBuilder.AddRemoteSchema(source.Name);
            };

            var sources = builder.Configuration
                .GetSection("Server:Api:Stitching:Sources")
                .Get<IEnumerable<ApiStitchingSourceConfiguration>>();

            foreach (var source in sources)
                addStitchingSource(source);
        }

        /// <summary>
        /// Add neccessary services used by the Api layer
        /// </summary>
        /// <param name="app">App to attach to</param>
        public static void UseApi(this WebApplication app)
        {
            app.UseRouting();
            app.UseHeaderPropagation();
            app.UseEndpoints(endpoints => endpoints
                .MapGraphQL()
                .WithOptions(new GraphQLServerOptions
                {
                    Tool =
                    {
                        Enable = false
                    }
                }));
        }
    }
}