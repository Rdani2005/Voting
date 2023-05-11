using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Models
{
    public class Voter
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public String? Identification { get; set; }
        [Required]
        public String? Name { get; set; }
        [Required]
        public String? LastName { get; set; }

        [Required]
        public Year? year { get; set; }
        [Required]
        public int YearId { get; set; }
        [Required]
        public Specialty? Specialty { get; set; }
        [Required]
        public int SpecialtyId { get; set; }

        public Vote? Vote { get; set; }
    }
}