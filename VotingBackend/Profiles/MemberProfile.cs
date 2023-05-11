using AutoMapper;
using VotingBackend.Dtos.Members;
using VotingBackend.Models;

namespace VotingBackend.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            // Source -> Target
            CreateMap<PoliticalMember, ReadMemberDto>();
            CreateMap<PoliticalMemberType, MemberTypeReadDto>();
            CreateMap<AddMemberDto, PoliticalMember>();
            CreateMap<AddMemberTypeDto, PoliticalMemberType>();
        }
    }
}