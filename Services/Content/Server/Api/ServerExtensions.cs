using AutoMapper;
using HotChocolate.Types.Pagination;
using RunSynopsis.Application.Search;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Content;
using RunSynopsis.Server.Api.Descriptors;
using RunSynopsis.Server.Api.Interceptors;
using RunSynopsis.Server.Auth;

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
                .RegisterService<IMapper>(ServiceKind.Synchronized)
                .RegisterService<IAuthService>(ServiceKind.Synchronized)
                .RegisterService<IUserContext>(ServiceKind.Synchronized)
                .RegisterService<IContentService>(ServiceKind.Synchronized)
                .RegisterService<ISearchService>(ServiceKind.Synchronized)
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>()
                .AddType<AuthorType>()
                .AddType<ArticleType>()
                .AddType<ArticleFilterInputType>()
                .AddType<ArticleSortInputType>()
                .AddType<CreateArticleRequestInputType>()
                .AddType<UpdateArticleRequestInputType>()
                .AddType<CategoryType>()
                .AddType<CategoryFilterInputType>()
                .AddType<CategorySortInputType>()
                .AddType<CreateCategoryRequestInputType>()
                .AddType<UpdateCategoryRequestInputType>()
                .AddType<PermissionType>()
                .AddType<PostType>()
                .AddType<PostFilterInputType>()
                .AddType<PostSortInputType>()
                .AddType<CreatePostRequestInputType>()
                .AddType<UpdatePostRequestInputType>()
                .AddType<TagType>()
                .AddType<TagFilterInputType>()
                .AddType<TagSortInputType>()
                .AddType<CreateTagRequestInputType>()
                .AddType<UpdateTagRequestInputType>()
                .SetPagingOptions(new PagingOptions
                {
                    IncludeTotalCount = true,
                    DefaultPageSize = 20,
                    MaxPageSize = 20,
                    InferConnectionNameFromField = true
                })
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