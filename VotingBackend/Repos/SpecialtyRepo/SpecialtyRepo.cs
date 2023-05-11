using VotingBackend.Data;
using VotingBackend.Models;

namespace VotingBackend.Repos.SpecialtyRepo
{
    public class SpecialtyRepo : ISpecialtyRepo
    {
        private readonly AppDbContext _context;

        public SpecialtyRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateSpecialty(Specialty specialty)
        {
            if (specialty == null)
                throw new ArgumentNullException(nameof(specialty));
            _context.Specialties.Add(specialty);
            _context.SaveChanges();
        }

        public IEnumerable<Specialty> GetAllSpecialties()
        {
            return _context.Specialties.ToList();
        }

        public Specialty? GetSpecialty(int id) =>
                _context
                    .Specialties
                    .FirstOrDefault(s => s.Id == id);
    }
}