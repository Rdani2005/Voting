using System.ComponentModel.DataAnnotations;

namespace VotingBackend.Models
{
    public class SupportUser
    {
        [Key]
        [Required]
        public int Id { get; set; }
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