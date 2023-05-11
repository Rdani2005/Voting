using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Dtos.Parties
{
    public class AddPartyDto
    {
        [Required]
        public String? Name { get; set; }
        [Required]
        public String? PetUrl { get; set; }
        [Required]
        public String? ImageUrl { get; set; }
    }
}