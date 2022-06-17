using AutoMapper;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Server.Auth.Entities;

namespace RunSynopsis.Server.Auth
{
    public class AuthAutoMapperProfile : Profile
    {
        public AuthAutoMapperProfile()
        {
            CreateMap<User, AuthUser>()
                .ReverseMap();

            CreateMap<Token, AuthToken>()
                .ReverseMap();

            CreateMap<Permission, AuthPermission>()
                .ReverseMap();
        }
    }
}