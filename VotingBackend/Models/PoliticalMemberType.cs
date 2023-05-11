using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Models
{
    public class PoliticalMemberType
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public String? Name { get; set; }
        public ICollection<PoliticalMember>? Members { get; set; }
    }
}