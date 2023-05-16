using VotingBackend.Data;
using VotingBackend.Models;

namespace VotingBackend.Repos.VoterRepo
{
    public class VoterRepo : IVoterRepo
    {
        private readonly AppDbContext _context;

        public VoterRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateVoter(Voter voter)
        {
            if (voter == null) throw new ArgumentNullException(nameof(voter));
            _context.Voters.Add(voter);
            _context.SaveChanges();

        }

        public IEnumerable<Voter> GetAllVoters()
        {
            return _context.Voters.ToList();
        }

        public Voter GetVoterById(int id) =>
            _context.Voters.FirstOrDefault(v => v.Id == id);

        public Voter GetVoterByIdentification(string identification) =>
            _context.Voters.FirstOrDefault(v => v.Identification.Equals(identification));



        public IEnumerable<Voter> GetVotersBySpecialtyAndYear(
            int yearId,
            int specialtyId
        ) =>
            _context.Voters.Where(
                v => v.YearId == yearId
                    && v.SpecialtyId == specialtyId
                );

        public IEnumerable<Voter> GetVotersByYear(int yearId) =>
            _context.Voters.Where(v => v.YearId == yearId);

        public Specialty GetVoterSpecialty(int specialtyId)
        {
            return _context.Specialties.FirstOrDefault(s => s.Id == specialtyId);
        }

        public Year GetVoterYear(int yearId)
        {
            return _context.Years.FirstOrDefault(y => y.Id == yearId);
        }
    }
}