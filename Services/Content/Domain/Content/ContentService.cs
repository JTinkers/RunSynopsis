using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RunSynopsis.Common.Exceptions;
using RunSynopsis.Domain.Auth;
using RunSynopsis.Domain.Content.Database;
using RunSynopsis.Domain.Content.Entities;
using RunSynopsis.Domain.Content.Payloads;
using RunSynopsis.Domain.Content.Ports;

namespace RunSynopsis.Domain.Content
{
    internal class ContentService : IContentService
    {
        private readonly ContentDbContext _context;

        private readonly IUserContext _userContext;

        private readonly ISlugifier _slugifier;

        private readonly IMapper _mapper;

        public ContentService(
            IDbContextFactory<ContentDbContext> contextFactory,
            IUserContext userContext,
            ISlugifier slugifier,
            IMapper mapper)
        {
            _context = contextFactory.CreateDbContext();
            _userContext = userContext;
            _slugifier = slugifier;
            _mapper = mapper;
        }

        public IQueryable<Author> GetAuthors() => _context.Authors;

        public IQueryable<Article> GetArticles() => _context.Articles;

        public IQueryable<Post> GetPosts() => _context.Posts;

        public IQueryable<Category> GetCategories() => _context.Categories;

        public IQueryable<Tag> GetTags() => _context.Tags;

        public async Task<Article> CreateArticleAsync(CreateArticleRequest request)
        {
            _userContext.Authorize(ContentPermission.CreateArticle);

            var category = await _context.Categories.FindAsync(request.CategoryId);

            if (category is null)
                throw new EntityNotFoundException<Category>();

            var user = _userContext.GetUser()!;

            var author = await _context.Authors.FindAsync(user.Id);

            author ??= _mapper.Map<Author>(user);

            var slug = _slugifier.Make(request.Title);

            var article = new Article(
                author,
                category,
                request.HeaderSrc,
                request.Title,
                slug,
                request.Synopsis,
                request.Content);

            var tags = request.TagIds?
                .Select(id => new Tag { Id = id });

            if (tags?.Any() == true)
                article.Tags = article.Tags.Concat(tags).ToList();

            await _context.AddAsync(article);
            await _context.SaveChangesAsync();

            return article;
        }

        public async Task<Category> CreateCategoryAsync(CreateCategoryRequest request)
        {
            _userContext.Authorize(ContentPermission.CreateCategory);

            var category = new Category(request.Name, request.Description);

            await _context.AddAsync(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Post> CreatePostAsync(CreatePostRequest request)
        {
            _userContext.Authorize(ContentPermission.CreatePost);

            var category = await _context.Categories.FindAsync(request.CategoryId);

            if (category is null)
                throw new EntityNotFoundException<Category>();

            var user = _userContext.GetUser()!;

            var author = await _context.Authors.FindAsync(user.Id);

            author ??= _mapper.Map<Author>(user);

            var slug = _slugifier.Make(request.Title);

            var post = new Post(
                author,
                category,
                request.Title,
                slug,
                request.Content);

            var tags = request.TagIds?
                .Select(id => new Tag { Id = id });

            if (tags?.Any() == true)
                post.Tags = post.Tags.Concat(tags).ToList();

            await _context.AddAsync(post);
            await _context.SaveChangesAsync();

            return post;
        }

        public async Task<Tag> CreateTagAsync(CreateTagRequest request)
        {
            _userContext.Authorize(ContentPermission.CreateTag);

            var tag = new Tag(request.Name, request.Description);

            await _context.AddAsync(tag);
            await _context.SaveChangesAsync();

            return tag;
        }

        public async Task DeleteArticleAsync(Article article)
        {
            _userContext.Authorize(ContentPermission.DeleteArticle);

            _context.Articles.Remove(article);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(Category category)
        {
            _userContext.Authorize(ContentPermission.DeleteCategory);

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();
        }

        public async Task DeletePostAsync(Post post)
        {
            _userContext.Authorize(ContentPermission.DeletePost);

            _context.Posts.Remove(post);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteTagAsync(Tag tag)
        {
            _userContext.Authorize(ContentPermission.DeleteTag);

            _context.Tags.Remove(tag);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateArticleAsync(UpdateArticleRequest request)
        {
            _userContext.Authorize(ContentPermission.CreateArticle);

            var article = await _context.Articles
                .FindAsync(request.Id);

            if (article is null)
                throw new EntityNotFoundException<Article>();

            if (request.CategoryId.HasValue)
                article.CategoryId = request.CategoryId.Value;

            if (request.HeaderSrc is not null)
                article.HeaderSrc = request.HeaderSrc;

            if (request.Title is not null)
                article.Title = request.Title;

            if (request.Synopsis is not null)
                article.Synopsis = request.Synopsis;

            if (request.Content is not null)
                article.Content = request.Content;

            article.UpdatedAt = DateTime.UtcNow;

            _context.Update(article);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryRequest request)
        {
            _userContext.Authorize(ContentPermission.CreateCategory);

            var category = await _context.Categories
                .FindAsync(request.Id);

            if (category is null)
                throw new EntityNotFoundException<Category>();

            if (request.Name is not null)
                category.Name = request.Name;

            if (request.Description is not null)
                category.Description = request.Description;

            _context.Update(category);

            await _context.SaveChangesAsync();
        }

        public async Task UpdatePostAsync(UpdatePostRequest request)
        {
            _userContext.Authorize(ContentPermission.CreatePost);

            var post = await _context.Posts
                .FindAsync(request.Id);

            if (post is null)
                throw new EntityNotFoundException<Post>();

            if (request.CategoryId.HasValue)
                post.CategoryId = request.CategoryId.Value;

            if (request.Title is not null)
                post.Title = request.Title;

            if (request.Content is not null)
                post.Content = request.Content;

            post.UpdatedAt = DateTime.UtcNow;

            _context.Update(post);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateTagAsync(UpdateTagRequest request)
        {
            _userContext.Authorize(ContentPermission.CreateTag);

            var tag = await _context.Tags
                .FindAsync(request.Id);

            if (tag is null)
                throw new EntityNotFoundException<Tag>();

            if (request.Name is not null)
                tag.Name = request.Name;

            if (request.Description is not null)
                tag.Description = request.Description;

            _context.Update(tag);

            await _context.SaveChangesAsync();
        }
    }
}