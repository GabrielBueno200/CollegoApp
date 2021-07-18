using System.Threading.Tasks;
using Domain.Models.Security;

namespace Domain.Repositories.Interfaces
{
    public interface IRefreshTokenRepository {

        Task<RefreshToken> FindByTokenAsync(string refreshToken);

        Task CreateAsync(RefreshToken token);

        Task DeleteAsync(string token);
        
    }
}