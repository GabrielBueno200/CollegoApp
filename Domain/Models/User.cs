using Microsoft.AspNetCore.Identity;

namespace Domain{
    public class User : IdentityUser{
        
        public string FullName { get; set; }

        public string pass {get ; set; }
        
    }
}