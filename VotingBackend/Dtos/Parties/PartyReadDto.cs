using VotingBackend.Dtos.Members;

namespace VotingBackend.Dtos.Parties
{
    public class PartyReadDto
    {
        public int Id { get; set; }
        public String? Name { get; set; }
        public String? PetUrl { get; set; }
        public String? ImageUrl { get; set; }
        public ICollection<ReadMemberDto>? Members { get; set; }
    }
}