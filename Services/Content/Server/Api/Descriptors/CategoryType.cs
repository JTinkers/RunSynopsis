using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class CategoryType : ObjectType<Category>
    {
        protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
        {
            descriptor.Field(x => x.Id).ID();
            descriptor.Field(x => x.Name);
            descriptor.Field(x => x.Description);
        }
    }
}