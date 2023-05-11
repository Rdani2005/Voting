using VotingBackend.Models;

namespace VotingBackend.Repos.PoliticalMemberRepo
{
    public interface IPoliticalMemberRepo
    {
        void CreateMember(PoliticalMember member);

        IEnumerable<PoliticalMember> GetAllMembers(int PartyId);

        PoliticalMember GetMemberById(int id);
    }
}