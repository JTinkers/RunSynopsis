using RunSynopsis.Application.Search;
using RunSynopsis.Application.Search.QueryBuilders;
using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Application
{
    public static class ServerExtensions
    {
        public static void AddSearch(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<ISearchService, SearchService>()
                .AddScoped<IQueryBuilder<Article>, ArticleQueryBuilder>()
                .AddScoped<IQueryBuilder<Post>, PostQueryBuilder>();
        }
    }
}