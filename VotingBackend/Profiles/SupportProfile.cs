using AutoMapper;
using VotingBackend.Dtos.Support;
using VotingBackend.Models;

namespace VotingBackend.Profiles
{
    public class SupportProfile : Profile
    {
        public SupportProfile()
        {
            // Source -> Target
            CreateMap<SupportUser, ReadSupportDto>();
            CreateMap<AddSupportDto, SupportUser>();
        }
    }
}