using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Dtos.Support
{
    public class AddSupportDto
    {
        [Required]
        public String Identification { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String Password { get; set; }
    }
}