using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Dtos.Members
{
    public class AddMemberTypeDto
    {
        [Required]
        public String? Name { get; set; }

    }
}