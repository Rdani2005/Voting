using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Dtos.Voter
{
    public class AddVoter
    {

        [Required]
        public String? Identification { get; set; }
        [Required]
        public String? Name { get; set; }
        [Required]
        public String? LastName { get; set; }
        [Required]
        public int YearId { get; set; }
        [Required]
        public int SpecialtyId { get; set; }
    }
}