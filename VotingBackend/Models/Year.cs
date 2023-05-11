namespace VotingBackend.Models
{
    public class Year
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public ICollection<Voter>? Voters { get; set; }
    }
}