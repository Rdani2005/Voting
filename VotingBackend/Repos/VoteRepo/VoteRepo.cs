using VotingBackend.Data;
using VotingBackend.Models;

namespace VotingBackend.Repos.VoteRepo
{
    public class VoteRepo : IVoteRepo
    {
        private readonly AppDbContext _context;

        public VoteRepo(AppDbContext context)
        {
            _context = context;
        }

        public bool UserHasVote(int userId) =>
            _context.Votes.FirstOrDefault(v => v.VoterId == userId) != null;

        public void UseVote(Vote vote)
        {
            _context.Votes.Add(
                vote
            );
            _context.SaveChanges();
        }
    }
}