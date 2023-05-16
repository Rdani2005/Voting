using VotingBackend.Models;

namespace VotingBackend.Repos.PoliticalPartyRepo
{
    public interface IPoliticalRepo
    {
        void CreatePoliticalParty(PoliticalParty politicalParty);
        IEnumerable<PoliticalParty> GetPoliticalParties();
        PoliticalParty GetPoliticalPartyById(int id);

        int GetPoliticalPartyVotesCount(int id);
    }
}