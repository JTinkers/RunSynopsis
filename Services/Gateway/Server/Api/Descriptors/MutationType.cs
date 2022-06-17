namespace RunSynopsis.Server.Api.Descriptors
{
    public class MutationType : ObjectTypeExtension<Mutation>
    {
        protected override void Configure(IObjectTypeDescriptor<Mutation> descriptor)
        {
            descriptor.Field(x => x.SignInAsync(default!, default!, default!, default!))
                .Name("gateway_signIn");

            descriptor.Field(x => x.SignOutAsync(default!))
                .Name("gateway_signOut");
        }
    }
}