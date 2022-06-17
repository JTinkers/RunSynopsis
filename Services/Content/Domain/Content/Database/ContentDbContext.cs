using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using RunSynopsis.Domain.Content.Entities;
using RunSynopsis.Domain.Content.Ports;

namespace RunSynopsis.Domain.Content.Database
{
    public class ContentDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public ContentDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var slugifier = Database.GetService<ISlugifier>();

            modelBuilder.Entity<Author>(e =>
            {
                e.HasMany(x => x.Articles)
                    .WithOne(x => x.Author)
                    .OnDelete(DeleteBehavior.NoAction);

                e.HasMany(x => x.Posts)
                    .WithOne(x => x.Author)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Article>(e =>
            {
                e.HasMany(x => x.Tags)
                    .WithMany(x => x.Articles)
                    .UsingEntity<Dictionary<string, object>>("ArticleTag",
                        x => x.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.NoAction),
                        x => x.HasOne<Article>().WithMany().HasForeignKey("ArticleId").OnDelete(DeleteBehavior.NoAction),
                        x => x.ToTable("ArticleTags"));

                e.HasOne(x => x.Author)
                    .WithMany(x => x.Articles)
                    .OnDelete(DeleteBehavior.NoAction);

                e.HasOne(x => x.Category)
                    .WithMany(x => x.Articles)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Post>(e =>
            {
                e.HasMany(x => x.Tags)
                    .WithMany(x => x.Posts)
                    .UsingEntity<Dictionary<string, object>>("PostTag",
                        x => x.HasOne<Tag>().WithMany().HasForeignKey("TagId").OnDelete(DeleteBehavior.NoAction),
                        x => x.HasOne<Post>().WithMany().HasForeignKey("PostId").OnDelete(DeleteBehavior.NoAction),
                        x => x.ToTable("PostTags"));

                e.HasOne(x => x.Author)
                    .WithMany(x => x.Posts)
                    .OnDelete(DeleteBehavior.NoAction);

                e.HasOne(x => x.Category)
                    .WithMany(x => x.Posts)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.HasIndex(x => x.Name)
                    .IsUnique();
            });

            modelBuilder.Entity<Tag>(e =>
            {
                e.HasIndex(x => x.Name)
                    .IsUnique();
            });

            var categoryId = 1;
            var categories = new Faker<Category>()
                .RuleFor(x => x.Id, _ => categoryId++)
                .RuleFor(x => x.Name, x => x.Commerce.Categories(1).First() + categoryId)
                .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
                .Generate(50);

            var tagId = 1;
            var tags = new Faker<Tag>()
                .RuleFor(x => x.Id, _ => tagId++)
                .RuleFor(x => x.Name, x => x.Vehicle.Model() + tagId)
                .RuleFor(x => x.Description, x => x.Commerce.ProductDescription())
                .Generate(50);

            var authorId = 1;
            var authors = new Faker<Author>()
                .RuleFor(x => x.Id, _ => authorId++)
                .RuleFor(x => x.Nickname, x => x.Person.FullName)
                .RuleFor(x => x.AvatarUrl, x => new Uri(x.Internet.Avatar()))
                .RuleFor(x => x.HomepageUrl, x => new Uri(x.Internet.Url()))
                .RuleFor(x => x.Bio, "My amazing bio")
                .Generate(5);

            var articleId = 1;
            var articles = new Faker<Article>()
                .RuleFor(x => x.Id, _ => articleId++)
                .RuleFor(x => x.AuthorId, x => x.PickRandom(authors).Id)
                .RuleFor(x => x.CategoryId, x => x.PickRandom(categories).Id)
                .RuleFor(x => x.Content, x => x.Rant.Review("Gezorb"))
                .RuleFor(x => x.Synopsis, x => x.Random.Words(32))
                .RuleFor(x => x.Title, x => x.Random.Words(x.Random.Number(4, 16)))
                .RuleFor(x => x.Slug, (_, x) => slugifier.Make(x.Title))
                .RuleFor(x => x.UpdatedAt, x => x.Date.Past(10, DateTime.UtcNow))
                .RuleFor(x => x.WrittenAt, x => x.Date.Past(10, DateTime.UtcNow))
                .RuleFor(x => x.HeaderSrc, x => x.Image.PicsumUrl(1024, 768))
                .Generate(50);

            var postId = 1;
            var posts = new Faker<Post>()
                .RuleFor(x => x.Id, _ => postId++)
                .RuleFor(x => x.AuthorId, x => x.PickRandom(authors).Id)
                .RuleFor(x => x.CategoryId, x => x.PickRandom(categories).Id)
                .RuleFor(x => x.Content, x => x.Random.Words(x.Random.Number(1, 20)))
                .RuleFor(x => x.Title, x => x.Random.Words(x.Random.Number(1, 10)))
                .RuleFor(x => x.Slug, (_, x) => slugifier.Make(x.Title))
                .RuleFor(x => x.UpdatedAt, x => x.Date.Past(10, DateTime.UtcNow))
                .RuleFor(x => x.WrittenAt, x => x.Date.Past(10, DateTime.UtcNow))
                .Generate(50);

            var faker = new Faker();
            var articleTags = Enumerable.Range(1, 250)
                .Select(_ => new
                {
                    TagId = faker.PickRandom(tags).Id,
                    ArticleId = faker.PickRandom(articles).Id
                })
                .DistinctBy(x => new { x.TagId, x.ArticleId })
                .ToList();

            var postTags = Enumerable.Range(1, 250)
                .Select(_ => new
                {
                    TagId = faker.PickRandom(tags).Id,
                    PostId = faker.PickRandom(posts).Id
                })
                .DistinctBy(x => new { x.TagId, x.PostId })
                .ToList();

            modelBuilder.Entity<Category>()
                .HasData(categories);

            modelBuilder.Entity<Tag>()
                .HasData(tags);

            modelBuilder.Entity<Author>()
                .HasData(authors);

            modelBuilder.Entity<Article>()
                .HasData(articles);

            modelBuilder.Entity<Post>()
                .HasData(posts);

            modelBuilder.Entity("ArticleTag")
                .HasData(articleTags);

            modelBuilder.Entity("PostTag")
                .HasData(postTags);
        }
    }
}