using Domain.Models;

namespace Application.Services.Interfaces
{
    public interface ITokenGeneratorService {

        string GenerateToken (User user);
        
    }
}