using VotingBackend.Models;

namespace VotingBackend.Repos.PoliticalMemberRepo
{
    public interface IPoliticalMemberTypeRepo
    {
        PoliticalMemberType GetTypeById(int id);

        IEnumerable<PoliticalMemberType> GetAllTypes();
        void CreateType(PoliticalMemberType type);
    }
}