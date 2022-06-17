using RunSynopsis.Domain.Content;
using RunSynopsis.Domain.Content.Entities;
using RunSynopsis.Domain.Content.Payloads;

namespace RunSynopsis.Server.Api
{
    public class Mutation
    {
        public async Task<Article> CreateArticleAsync(
            IContentService service,
            CreateArticleRequest request)
        {
            return await service.CreateArticleAsync(request);
        }

        public async Task<Post> CreatePostAsync(
            IContentService service,
            CreatePostRequest request)
        {
            return await service.CreatePostAsync(request);
        }

        public async Task<Category> CreateCategoryAsync(
            IContentService service,
            CreateCategoryRequest request)
        {
            return await service.CreateCategoryAsync(request);
        }

        public async Task<Tag> CreateTagAsync(
            IContentService service,
            CreateTagRequest request)
        {
            return await service.CreateTagAsync(request);
        }

        public async Task<bool> UpdateArticleAsync(
            IContentService service,
            UpdateArticleRequest request)
        {
            await service.UpdateArticleAsync(request);

            return true;
        }

        public async Task<bool> UpdateCategoryAsync(
            IContentService service,
            UpdateCategoryRequest request)
        {
            await service.UpdateCategoryAsync(request);

            return true;
        }

        public async Task<bool> UpdatePostAsync(
            IContentService service,
            UpdatePostRequest request)
        {
            await service.UpdatePostAsync(request);

            return true;
        }

        public async Task<bool> UpdateTagAsync(
            IContentService service,
            UpdateTagRequest request)
        {
            await service.UpdateTagAsync(request);

            return true;
        }

        public async Task<bool> DeleteArticleAsync(
            IContentService service,
            [ID] long id)
        {
            var article = new Article
            {
                Id = id
            };

            await service.DeleteArticleAsync(article);

            return true;
        }

        public async Task<bool> DeleteCategoryAsync(
            IContentService service,
            [ID] long id)
        {
            var category = new Category
            {
                Id = id
            };

            await service.DeleteCategoryAsync(category);

            return true;
        }

        public async Task<bool> DeleteTagAsync(
            IContentService service,
            [ID] long id)
        {
            var tag = new Tag
            {
                Id = id
            };

            await service.DeleteTagAsync(tag);

            return true;
        }

        public async Task<bool> DeletePostAsync(
            IContentService service,
            [ID] long id)
        {
            var post = new Post
            {
                Id = id
            };

            await service.DeletePostAsync(post);

            return true;
        }
    }
}