using RunSynopsis.Domain.Contact.Entities;
using RunSynopsis.Server.Api.Middleware;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(x => x.SubmitAsync(default!, default!))
                .Name("contact_submit");

            descriptor.Field(x => x.DeleteAsync(default!, default!))
                .Name("contact_delete")
                .UseAuth(ContactPermission.Delete);
        }
    }
}