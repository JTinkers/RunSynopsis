using AutoMapper;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Domain.Auth.Entities;

namespace RunSynopsis.Server.Auth
{
    public class AuthAutoMapperProfile : Profile
    {
        public AuthAutoMapperProfile()
        {
            CreateMap<User, AuthUser>()
                .ReverseMap();
        }
    }
}