using RunSynopsis.Domain.Storage;
using RunSynopsis.Server.Api.Descriptors;
using RunSynopsis.Server.Api.Interceptors;

namespace RunSynopsis.Server.Api
{
    public static class ServerExtensions
    {
        public static void AddApi(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddHttpContextAccessor()
                .AddScoped<Query>()
                .AddScoped<Mutation>()
                .AddGraphQLServer()
                .ModifyOptions(x =>
                {
                    x.DefaultBindingBehavior = BindingBehavior.Explicit;
                    x.SortFieldsByName = true;
                    x.ValidatePipelineOrder = true;
                })
                .ModifyRequestOptions(x =>
                {
                    x.IncludeExceptionDetails = builder.Environment.IsDevelopment();
                    x.ExecutionTimeout = TimeSpan.FromSeconds(60);
                })
                .RegisterService<IMediaService>(ServiceKind.Resolver)
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>()
                .AddType<MediaType>()
                .AddType<MediaFilterInputType>()
                .AddType<MediaSortInputType>()
                .AddType<UploadType>()
                .AddSorting()
                .AddFiltering()
                .AddGlobalObjectIdentification(false)
                .AddHttpRequestInterceptor<AuthRequestInterceptor>()
                .InitializeOnStartup();
        }

        public static void UseApi(this WebApplication app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapGraphQL());
        }
    }
}