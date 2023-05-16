using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Dtos.Specialty
{
    public class AddYearDto
    {
        [Required]
        public String Name { get; set; }
    }
}