using System;

namespace Application.Security.Entities
{
    public class AuthenticationResult{
        
        public bool Authenticated { get; set; }
        
        public DateTime Created { get; set; }

        public DateTime Expiry { get; set; }

        public string RefreshToken { get; set; }

        public string AccessToken { get; set; }

    }
}