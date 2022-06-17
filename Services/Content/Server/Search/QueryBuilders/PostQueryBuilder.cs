using RunSynopsis.Domain.Content;
using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Application.Search.QueryBuilders
{
    public class PostQueryBuilder : IQueryBuilder<Post>
    {
        private readonly IContentService _contentService;

        public PostQueryBuilder(IContentService contentService)
        {
            _contentService = contentService;
        }

        public IQueryable<Post> Build(string query)
        {
            var queryable = _contentService.GetPosts()
                .Where(x => x.Title.ToLower().Contains(query));

            return queryable;
        }
    }
}