using AutoMapper;
using RunSynopsis.Common.Bus.Contracts;
using RunSynopsis.Domain.Mailing.Entities;

namespace RunSynopsis.Server.Bus
{
    public class BusAutoMapperProfile : Profile
    {
        public BusAutoMapperProfile()
        {
            CreateMap<Recipient, MailingRecipient>()
                .ReverseMap();
        }
    }
}