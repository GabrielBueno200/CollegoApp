namespace Application.Core.DTOs
{
    public class UserRegisterDTO{

        public string userName { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }

        public double University { get; set; }

        public string CourseId { get; set; }

        public string NotListedCourse { get; set; }

        public bool TermsAccepted { get; set; }

        public byte[] ProfileThumbnail { get; set; } 
        
    }



}