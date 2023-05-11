namespace VotingBackend.Dtos.Members
{
    public class ReadMemberDto
    {
        public int Id { get; set; }
        public String? Identification { get; set; }
        public String? Name { get; set; }
        public MemberTypeReadDto Type { get; set; }
        public int PoliticalPartyId { get; set; }
    }
}