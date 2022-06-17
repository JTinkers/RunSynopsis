using Microsoft.Extensions.DependencyInjection;

namespace RunSynopsis.Application.Search
{
    internal class SearchService : ISearchService
    {
        private const int LIMIT_RESULTS = 10;

        private readonly IServiceProvider _services;

        public SearchService(IServiceProvider services)
        {
            _services = services;
        }

        public IQueryable<TEntity> Find<TEntity>(string query) where TEntity : class
        {
            var queryBuilder = GetQueryBuilder<TEntity>();

            if (queryBuilder is null)
                throw new InvalidOperationException($"No search query builder was found for {typeof(TEntity)}");

            return queryBuilder
                .Build(query)
                .Take(LIMIT_RESULTS);
        }

        private IQueryBuilder<TEntity>? GetQueryBuilder<TEntity>() where TEntity : class
        {
            return _services.GetRequiredService<IQueryBuilder<TEntity>>();
        }
    }
}