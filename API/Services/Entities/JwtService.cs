using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using API.Services.Interfaces;
using API.Settings;
using Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Services.Entities
{
    public class JwtService : IJwtService {

        private readonly JWTPayload _JWTPayload;

        public JwtService(IOptions<JWTPayload> JWTPayload){
            _JWTPayload = JWTPayload.Value;
        }

        public string GenerateToken(User user) {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_JWTPayload.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _JWTPayload.Issuer,
                Audience = _JWTPayload.Audience,
                Expires = DateTime.UtcNow.AddMinutes(_JWTPayload.Expires_In),
                SigningCredentials = new SigningCredentials(
                    key: new SymmetricSecurityKey(key),
                    algorithm: SecurityAlgorithms.HmacSha256Signature
                )
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(securityToken);

            return token;

        }
    }
}