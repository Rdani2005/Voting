namespace VotingBackend.Models
{
    public class Year
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<Voter>? Voters { get; set; }
    }
}