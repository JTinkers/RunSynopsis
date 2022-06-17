using RunSynopsis.Application.Search;
using RunSynopsis.Domain.Content;
using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Server.Api
{
    public class Query
    {
        public IQueryable<Author> GetAuthors(IContentService service)
        {
            return service.GetAuthors();
        }

        public IQueryable<Article> GetArticles(IContentService service)
        {
            return service.GetArticles();
        }

        public IQueryable<Article> GetArticle(IContentService service, [ID] long id)
        {
            return service.GetArticles().Where(x => x.Id == id);
        }

        public IQueryable<Category> GetCategories(IContentService service)
        {
            return service.GetCategories();
        }

        public IQueryable<Post> GetPosts(IContentService service)
        {
            return service.GetPosts();
        }

        public IQueryable<Post> GetPost(IContentService service, [ID] long id)
        {
            return service.GetPosts().Where(x => x.Id == id);
        }

        public IQueryable<Tag> GetTags(IContentService service)
        {
            return service.GetTags();
        }

        public IQueryable<Article> FindArticles(ISearchService service, string query)
        {
            return service.Find<Article>(query);
        }

        public IQueryable<Post> FindPosts(ISearchService service, string query)
        {
            return service.Find<Post>(query);
        }
    }
}