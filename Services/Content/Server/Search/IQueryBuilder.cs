namespace RunSynopsis.Application.Search
{
    public interface IQueryBuilder<out TEntity> where TEntity : class
    {
        IQueryable<TEntity> Build(string query);
    }
}