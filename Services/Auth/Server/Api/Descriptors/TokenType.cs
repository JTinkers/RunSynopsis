using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Api.Descriptors
{
    public class TokenType : ObjectType<Token>
    {
        protected override void Configure(IObjectTypeDescriptor<Token> descriptor)
        {
            descriptor.Field(x => x.Type);
            descriptor.Field(x => x.Value);
        }
    }
}