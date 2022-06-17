using AutoMapper;
using RunSynopsis.Domain.Auth.Entities;
using RunSynopsis.Domain.Content.Entities;

namespace RunSynopsis.Domain.Content
{
    internal class ContentAutoMapperProfile : Profile
    {
        public ContentAutoMapperProfile()
        {
            CreateMap<Author, User>()
                .ReverseMap();
        }
    }
}