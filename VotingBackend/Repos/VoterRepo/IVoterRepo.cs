using VotingBackend.Models;

namespace VotingBackend.Repos.VoterRepo
{
    public interface IVoterRepo
    {
        void CreateVoter(Voter voter);
        IEnumerable<Voter> GetAllVoters();
        Voter GetVoterById(int id);
        Year GetVoterYear(int yearId);
        Specialty GetVoterSpecialty(int specialtyId);
        Voter GetVoterByIdentification(String identification);
        IEnumerable<Voter> GetVotersByYear(int yearId);
        IEnumerable<Voter> GetVotersBySpecialtyAndYear(int yearId, int specialtyId);
    }
}