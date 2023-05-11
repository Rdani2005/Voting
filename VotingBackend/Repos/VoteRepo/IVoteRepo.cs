using VotingBackend.Models;

namespace VotingBackend.Repos.VoteRepo
{
    public interface IVoteRepo
    {
        void UseVote(Vote vote);
        bool UserHasVote(int userId);
    }
}