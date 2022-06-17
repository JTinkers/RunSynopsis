namespace RunSynopsis.Server.Api.Descriptors
{
    public class MutationType : ObjectType<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(x => x.SignUpAsync(default!, default!))
                .Name("newsletter_signUp");

            descriptor.Field(x => x.SignOutAsync(default!, Guid.Empty))
                .Name("newsletter_signOut");
        }
    }
}