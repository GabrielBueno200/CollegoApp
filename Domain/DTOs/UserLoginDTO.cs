using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class UserLoginDTO {

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password {get; set; }
        
        [Compare("Password")]
        public string confirmPassword {get; set;}
        
    }
}