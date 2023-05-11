using VotingBackend.Data;
using VotingBackend.Models;

namespace VotingBackend.Repos.SupportUserRepo
{
    public class SupporUserRepo : ISupportUserRepo
    {
        private readonly AppDbContext _context;

        public SupporUserRepo(AppDbContext context)
        {
            _context = context;
        }
        public void CreateSupportUser(SupportUser supportUser)
        {
            if (supportUser == null) throw new ArgumentNullException(nameof(supportUser));
            _context.SupportUsers.Add(supportUser);
            _context.SaveChanges();
        }
        public IEnumerable<SupportUser> GetAllUsers()
        {
            return _context.SupportUsers.ToList();
        }

        public SupportUser? GetSupportUser(
            string Identification,
            string password
        ) =>
                _context.SupportUsers.FirstOrDefault(
                    s =>
                        s.Identification == Identification
                        && s.Password == password
            );

        public SupportUser? GetSupportUserById(int id) =>
            _context.SupportUsers.FirstOrDefault(u => u.Id == id);
    }
}