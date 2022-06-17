using RunSynopsis.Domain.Content;
using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Application.Search.QueryBuilders
{
    public class ArticleQueryBuilder : IQueryBuilder<Article>
    {
        private readonly IContentService _contentService;

        public ArticleQueryBuilder(IContentService contentService)
        {
            _contentService = contentService;
        }

        public IQueryable<Article> Build(string query)
        {
            var queryable = _contentService.GetArticles()
                .Where(x => x.Title.ToLower().Contains(query));

            return queryable;
        }
    }
}