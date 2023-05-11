using VotingBackend.Data;
using VotingBackend.Models;

namespace VotingBackend.Repos.PoliticalMemberRepo
{
    public class PoliticalMemberTypeRepo : IPoliticalMemberTypeRepo
    {
        private readonly AppDbContext _context;

        public PoliticalMemberTypeRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateType(PoliticalMemberType type)
        {

            if (type == null) throw new ArgumentNullException(nameof(type));
            _context.PoliticalMemberTypes.Add(type);
            _context.SaveChanges();
        }

        public IEnumerable<PoliticalMemberType> GetAllTypes()
        {
            return _context.PoliticalMemberTypes.ToList();
        }

        public PoliticalMemberType GetTypeById(int id)
        {
            return _context.PoliticalMemberTypes.FirstOrDefault(p => p.Id == id);
        }
    }
}