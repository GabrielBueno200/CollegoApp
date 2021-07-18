using Domain.Models;
using Application.Security.Entities;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface ITokenGeneratorService {

        Task<AuthenticationResult> GenerateTokenAsync(User user);

        string GenerateRefreshTokenString(); 
        
    }
}