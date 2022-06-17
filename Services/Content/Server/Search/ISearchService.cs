namespace RunSynopsis.Application.Search
{
    public interface ISearchService
    {
        IQueryable<TEntity> Find<TEntity>(string query) where TEntity : class;
    }
}