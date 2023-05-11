using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Dtos.Specialty
{
    public class AddSpecialtyDto
    {
        [Required]
        public int Name { get; set; }
    }
}