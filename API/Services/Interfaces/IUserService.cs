using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Services.Interfaces
{
    public interface IUserService {

        Task<IdentityResult> ValidateAsync(User user);

        Task AddToRoleAsync(User user, string roleName);

        Task<bool> IsEmailAvailable(string email);

        Task<bool> IsUsernameAvailable(string username);
        
    }
}