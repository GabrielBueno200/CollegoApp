using System.ComponentModel.DataAnnotations;

namespace Domain.DTOs
{
    public class UserLoginDTO {

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password {get; set; }
        
    }
}