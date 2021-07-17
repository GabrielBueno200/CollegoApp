using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Domain.Repositories.Interfaces
{
    public interface IUserRepository {

        Task CreateAsync(User user, string password);

        Task<IdentityResult> AddToRoleAsync(User user, string roleName);

        Task<User> FindByEmailAsync(string email);

        Task<User> FindByUsernameAsync(string username);

        Task<IdentityResult> ValidateAsync(IUserValidator<User> validator, User user);

        IQueryable<User> List();
        
    }
}