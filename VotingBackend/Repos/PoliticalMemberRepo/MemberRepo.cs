using VotingBackend.Data;
using VotingBackend.Models;

namespace VotingBackend.Repos.PoliticalMemberRepo
{
    public class MemberRepo : IPoliticalMemberRepo
    {
        private readonly AppDbContext _context;

        public MemberRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateMember(PoliticalMember member)
        {
            if (member == null) throw new ArgumentNullException(nameof(member));
            _context.PoliticalMembers.Add(member);
            _context.SaveChanges();
        }

        public IEnumerable<PoliticalMember> GetAllMembers(int PartyId)
        {
            return _context.PoliticalMembers.Where(p => p.PoliticalPartyId == PartyId);
        }

        public PoliticalMember GetMemberById(int id)
        {
            return _context.PoliticalMembers.FirstOrDefault(m => m.Id == id);
        }
    }
}