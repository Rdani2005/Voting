using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Dtos.Members
{
    public class AddMemberDto
    {
        [Required]
        public String? Identification { get; set; }

        [Required]
        public String? Name { get; set; }

        [Required]
        public int Type { get; set; }

        [Required]
        public int PoliticalPartyId { get; set; }
    }
}