using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Models
{
    public class Specialty
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }

        public ICollection<Voter>? Voters { get; set; }
    }
}