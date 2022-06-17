namespace RunSynopsis.Server.Api.Descriptors
{
    public class QueryType : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(x => x.Placeholder())
                .Name("mailing_placeholder");
        }
    }
}