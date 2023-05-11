using VotingBackend.Dtos.Specialty;

namespace VotingBackend.Dtos.Voter
{
    public class ReadVoter
    {
        public int Id { get; set; }
        public String? Identification { get; set; }
        public String? Name { get; set; }
        public String? LastName { get; set; }
        public YearReadDto? year { get; set; }
        public ReadSpecialtyDto? Specialty { get; set; }
    }
}