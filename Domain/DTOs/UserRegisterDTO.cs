namespace Domain.DTOs
{
    public class UserRegisterDTO{

        public string userName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }

        public byte[] ProfileThumbnail { get; set; } 
        
    }



}