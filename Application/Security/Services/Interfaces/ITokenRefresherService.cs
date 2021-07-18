using System.Security.Claims;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Application.Security.Entities;
using Domain.Models;

namespace Application.Security.Services.Interfaces
{
    public interface ITokenRefresherService {
        
        Task<AuthenticationResult> RefreshTokenAsync(string accessToken, string refreshToken);

    }
}