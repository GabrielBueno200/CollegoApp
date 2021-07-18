namespace Application.Security.Entities
{
    public class TokenSettings {

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public double Expires_In { get; set; }

        public string Secret { get; set; }

    }
}