using VotingBackend.Models;

namespace VotingBackend.Repos.SpecialtyRepo
{
    public interface ISpecialtyRepo
    {
        void CreateSpecialty(Specialty specialty);
        IEnumerable<Specialty> GetAllSpecialties();
        Specialty? GetSpecialty(int id);
    }
}