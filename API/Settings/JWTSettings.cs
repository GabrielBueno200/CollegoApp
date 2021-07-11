namespace API.Settings
{
    public class JWTSettings {
        
        public string Issuer { get; set; }

        public string Audience { get; set; }
        
        public int Expires_In { get; set; } 
        
        public string Secret { get; set; }
        
    }

}