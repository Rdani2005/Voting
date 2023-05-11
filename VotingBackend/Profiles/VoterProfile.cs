using AutoMapper;
using VotingBackend.Dtos.Specialty;
using VotingBackend.Dtos.Voter;
using VotingBackend.Models;

namespace VotingBackend.Profiles
{
    public class VoterProfile : Profile
    {
        public VoterProfile()
        {
            // Source -> Target
            CreateMap<AddVoter, Voter>();
            CreateMap<Voter, ReadVoter>();
            CreateMap<AddSpecialtyDto, Specialty>();
            CreateMap<Specialty, ReadSpecialtyDto>();
            CreateMap<AddYearDto, Year>();
            CreateMap<Year, YearReadDto>();
        }
    }
}