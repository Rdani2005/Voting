using VotingBackend.Models;

namespace VotingBackend.Repos.SupportUserRepo
{
    public interface ISupportUserRepo
    {
        void CreateSupportUser(SupportUser supportUser);

        IEnumerable<SupportUser> GetAllUsers();

        SupportUser? GetSupportUser(String Identification, String password);

        SupportUser? GetSupportUserById(int id);
    }
}