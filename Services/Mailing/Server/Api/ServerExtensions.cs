﻿using RunSynopsis.Domain.Mailing;
using RunSynopsis.Server.Api.Descriptors;

namespace RunSynopsis.Server.Api
{
    public static class ServerExtensions
    {
        public static void AddApi(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<Mutation>()
                .AddGraphQLServer()
                .ModifyOptions(x =>
                {
                    x.DefaultBindingBehavior = BindingBehavior.Explicit;
                    x.SortFieldsByName = true;
                    x.ValidatePipelineOrder = true;
                })
                .ModifyRequestOptions(x =>
                {
                    x.IncludeExceptionDetails = builder.Environment.IsDevelopment();
                    x.ExecutionTimeout = TimeSpan.FromSeconds(60);
                })
                .RegisterService<INewsletterService>(ServiceKind.Resolver)
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>()
                .AddGlobalObjectIdentification(false)
                .InitializeOnStartup();
        }

        public static void UseApi(this WebApplication app)
        {
            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapGraphQL());
        }
    }
}