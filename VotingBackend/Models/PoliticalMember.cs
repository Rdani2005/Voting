using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Models
{
    public class PoliticalMember
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public String? Identification { get; set; }
        [Required]
        public String? Name { get; set; }
        [Required]
        public PoliticalParty? PoliticalParty { get; set; }
        [Required]
        public PoliticalMemberType? Type { get; set; }
        public int PoliticalPartyId { get; set; }
    }
}