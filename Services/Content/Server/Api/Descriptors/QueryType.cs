namespace RunSynopsis.Server.Api.Descriptors
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(x => x.GetAuthors(default!))
                .Name("content_getAuthors")
                .UseProjection();

            descriptor.Field(x => x.GetArticles(default!))
                .Name("content_getArticles")
                .UsePaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting();

            descriptor.Field(x => x.GetArticle(default!, default!))
                .Name("content_getArticle")
                .UseProjection()
                .UseSingleOrDefault();

            descriptor.Field(x => x.GetCategories(default!))
                .Name("content_getCategories")
                .UsePaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting();

            descriptor.Field(x => x.GetPosts(default!))
                .Name("content_getPosts")
                .UsePaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting();

            descriptor.Field(x => x.GetPost(default!, default!))
                .Name("content_getPost")
                .UseProjection()
                .UseSingleOrDefault();

            descriptor.Field(x => x.GetTags(default!))
                .Name("content_getTags")
                .UsePaging()
                .UseProjection()
                .UseFiltering()
                .UseSorting();

            descriptor.Field(x => x.FindArticles(default!, default!))
                .Name("content_findArticles");

            descriptor.Field(x => x.FindPosts(default!, default!))
                .Name("content_findPosts");
        }
    }
}