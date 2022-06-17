using AutoMapper;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Domain.Auth.Entities;
using AuthPermission = RunSynopsis.Common.Bus.Contracts.AuthPermission;

namespace RunSynopsis.Server.Bus
{
    public class BusAutoMapperProfile : Profile
    {
        public BusAutoMapperProfile()
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