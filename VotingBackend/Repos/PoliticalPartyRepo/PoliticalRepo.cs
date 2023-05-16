using VotingBackend.Data;
using VotingBackend.Models;

namespace VotingBackend.Repos.PoliticalPartyRepo
{
    public class PoliticalRepo : IPoliticalRepo
    {
        private readonly AppDbContext _context;

        public PoliticalRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreatePoliticalParty(PoliticalParty politicalParty)
        {
            if (politicalParty == null) throw new ArgumentNullException(nameof(politicalParty));
            _context.PoliticalParties.Add(politicalParty);
            _context.SaveChanges();
        }

        public IEnumerable<PoliticalParty> GetPoliticalParties() =>
            _context.PoliticalParties.ToList();

        public PoliticalParty GetPoliticalPartyById(int id) =>
            _context.PoliticalParties.FirstOrDefault(p => p.Id == id);

        public int GetPoliticalPartyVotesCount(int id)
        {
            return _context.Votes.Where(v => v.PoliticalId == id).Count();
        }
    }
}