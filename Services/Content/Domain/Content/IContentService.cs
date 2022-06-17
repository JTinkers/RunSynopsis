using RunSynopsis.Domain.Content.Entities;
using RunSynopsis.Domain.Content.Payloads;

namespace RunSynopsis.Domain.Content
{
    public interface IContentService
    {
        IQueryable<Author> GetAuthors();

        IQueryable<Article> GetArticles();

        IQueryable<Post> GetPosts();

        IQueryable<Category> GetCategories();

        IQueryable<Tag> GetTags();

        Task<Article> CreateArticleAsync(CreateArticleRequest request);

        Task<Category> CreateCategoryAsync(CreateCategoryRequest request);

        Task<Post> CreatePostAsync(CreatePostRequest request);

        Task<Tag> CreateTagAsync(CreateTagRequest request);

        Task UpdateArticleAsync(UpdateArticleRequest request);

        Task UpdateCategoryAsync(UpdateCategoryRequest request);

        Task UpdateTagAsync(UpdateTagRequest request);

        Task UpdatePostAsync(UpdatePostRequest request);

        Task DeleteArticleAsync(Article article);

        Task DeleteCategoryAsync(Category category);

        Task DeletePostAsync(Post post);

        Task DeleteTagAsync(Tag tag);
    }
}