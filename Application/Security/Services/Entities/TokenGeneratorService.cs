using System.Net.Mime;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Application.Security.Entities;

namespace Application.Services.Entities
{
    public class TokenGeneratorService : ITokenGeneratorService {

        private readonly TokenPayload _TokenPayload;

        public TokenGeneratorService(IOptions<TokenPayload> TokenPayload){
            _TokenPayload = TokenPayload.Value;
        }

        public string GenerateToken(User user) {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_TokenPayload.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _TokenPayload.Issuer,
                Audience = _TokenPayload.Audience,
                Expires = DateTime.UtcNow.AddMinutes(_TokenPayload.Expires_In),
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