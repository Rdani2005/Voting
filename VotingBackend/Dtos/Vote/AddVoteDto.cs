using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Dtos.Vote
{
    public class AddVoteDto
    {
        [Required]
        public int PartyId { get; set; }
    }
}