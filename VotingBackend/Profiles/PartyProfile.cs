using AutoMapper;
using VotingBackend.Dtos.Parties;
using VotingBackend.Models;

namespace VotingBackend.Profiles
{
    public class PartyProfile : Profile
    {
        public PartyProfile()
        {
            // Source -> Target
            CreateMap<PoliticalParty, PartyReadDto>();
            CreateMap<AddPartyDto, PoliticalParty>();
        }
    }
}