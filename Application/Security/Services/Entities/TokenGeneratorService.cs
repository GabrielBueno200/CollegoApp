using System.Net.Mime;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Application.Services.Interfaces;
using Domain.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Application.Security.Entities;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using Domain.Repositories.Interfaces;
using Domain.Models.Security;
using System.Threading.Tasks;

namespace Application.Services.Entities
{
    public class TokenGeneratorService : ITokenGeneratorService {

        private readonly TokenSettings _TokenSettings;

        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public TokenGeneratorService(IOptions<TokenSettings> TokenSettings, 
                                    IRefreshTokenRepository refreshTokenRepository){
            _TokenSettings = TokenSettings.Value;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<AuthenticationResult> GenerateTokenAsync(User user) {

            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_TokenSettings.Secret);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _TokenSettings.Issuer,
                Audience = _TokenSettings.Audience,
                Expires = DateTime.UtcNow.AddMinutes(_TokenSettings.Expires_In),
                SigningCredentials = new SigningCredentials(
                    key: new SymmetricSecurityKey(key),
                    algorithm: SecurityAlgorithms.HmacSha256Signature
                )
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(securityToken);

            var refreshToken = GenerateRefreshTokenString();

            await _refreshTokenRepository.CreateAsync(new RefreshToken {
                Token = refreshToken,
                Created = DateTime.UtcNow,
                Expiry = DateTime.UtcNow.AddMinutes(_TokenSettings.Expires_In * 2),
                UserId = user.Id
            });

            return new AuthenticationResult {
                Authenticated = true,
                Created = DateTime.UtcNow,
                Expiry = DateTime.UtcNow.AddMinutes(_TokenSettings.Expires_In),
                AccessToken = token,
                RefreshToken = refreshToken
            };

        }

        public string GenerateRefreshTokenString(){

            var crypt = new RNGCryptoServiceProvider();

            var buf = new byte[24]; 
            crypt.GetBytes(buf);

            string result = Convert.ToBase64String(buf);

            return result;
        }
    }
}