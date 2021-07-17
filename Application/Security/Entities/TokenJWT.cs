namespace Application.Security.Entities
{
    public class TokenPayload {

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int Expires_In { get; set; }

        public string Secret { get; set; }

    }
}