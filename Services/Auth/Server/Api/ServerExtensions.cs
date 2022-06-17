using RunSynopsis.Domain.Auth;
using RunSynopsis.Server.Api.Descriptors;
using RunSynopsis.Server.Api.Interceptors;
using TokenType = RunSynopsis.Server.Api.Descriptors.TokenType;
using TokenTypeEnum = RunSynopsis.Domain.Auth.Entities.TokenType;

namespace RunSynopsis.Server.Api
{
    public static class ServerExtensions
    {
        public static void AddApi(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddOptions()
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
                .RegisterService<IAuthService>(ServiceKind.Synchronized)
                .RegisterService<IUserContext>(ServiceKind.Synchronized)
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>()
                .AddType<UserType>()
                .AddType<PermissionType>()
                .AddType<PermissionFilterInputType>()
                .AddType<PermissionSortInputType>()
                .AddType<UserFilterInputType>()
                .AddType<UserSortInputType>()
                .AddType<BanType>()
                .AddType<BanFilterInputType>()
                .AddType<BanSortInputType>()
                .AddType<TokenType>()
                .AddType<UpdateUserRequestType>()
                .AddEnumType<TokenTypeEnum>(descriptor => descriptor.BindValuesImplicitly())
                .AddSorting()
                .AddFiltering()
                .AddProjections()
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