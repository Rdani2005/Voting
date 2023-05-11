using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Models
{
    public class PoliticalParty
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public String? Name { get; set; }
        [Required]
        public String? PetUrl { get; set; }
        [Required]
        public String? ImageUrl { get; set; }
        public ICollection<PoliticalMember>? Members { get; set; }
        public ICollection<Vote>? Votes { get; set; }
    }
}