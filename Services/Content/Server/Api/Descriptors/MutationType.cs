using RunSynopsis.Domain.Content.Entities;
using RunSynopsis.Server.Api.Middleware;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(x => x.CreateArticleAsync(default!, default!))
                .Name("content_createArticle")
                .UseAuth(ContentPermission.CreateArticle);

            descriptor.Field(x => x.CreatePostAsync(default!, default!))
                .Name("content_createPost")
                .UseAuth(ContentPermission.CreatePost);

            descriptor.Field(x => x.CreateCategoryAsync(default!, default!))
                .Name("content_createCategory")
                .UseAuth(ContentPermission.CreateCategory);

            descriptor.Field(x => x.CreateTagAsync(default!, default!))
                .Name("content_createTag")
                .UseAuth(ContentPermission.CreateTag);

            descriptor.Field(x => x.UpdateArticleAsync(default!, default!))
                .Name("content_updateArticle")
                .UseAuth(ContentPermission.CreateArticle);

            descriptor.Field(x => x.UpdateCategoryAsync(default!, default!))
                .Name("content_updateCategory")
                .UseAuth(ContentPermission.CreateCategory);

            descriptor.Field(x => x.UpdatePostAsync(default!, default!))
                .Name("content_updatePost")
                .UseAuth(ContentPermission.CreatePost);

            descriptor.Field(x => x.UpdateTagAsync(default!, default!))
                .Name("content_updateTag")
                .UseAuth(ContentPermission.CreateTag);

            descriptor.Field(x => x.DeleteArticleAsync(default!, default!))
                .Name("content_deleteArticle")
                .UseAuth(ContentPermission.DeleteArticle);

            descriptor.Field(x => x.DeleteCategoryAsync(default!, default!))
                .Name("content_deleteCategory")
                .UseAuth(ContentPermission.DeleteCategory);

            descriptor.Field(x => x.DeletePostAsync(default!, default!))
                .Name("content_deletePost")
                .UseAuth(ContentPermission.DeletePost);

            descriptor.Field(x => x.DeleteTagAsync(default!, default!))
                .Name("content_deleteTag")
                .UseAuth(ContentPermission.DeleteTag);
        }
    }
}