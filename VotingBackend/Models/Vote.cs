using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Models
{
    public class Vote
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public Voter? Voter { get; set; }
        [Required]
        public int VoterId { get; set; }

        [Required]
        public PoliticalParty? PoliticalParty { get; set; }
        [Required]
        public int PoliticalId { get; set; }

    }
}