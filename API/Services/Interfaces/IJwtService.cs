using Domain.Models;

namespace API.Services.Interfaces
{
    public interface IJwtService {

        string GenerateToken (User user);
        
    }
}