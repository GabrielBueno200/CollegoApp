using System.Linq;
using System.Threading.Tasks;
using Domain.Repositories.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories.Entities
{
    public class UserRepository : IUserRepository {

        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager){
            _userManager = userManager;
        }

        public async Task CreateAsync(User user, string password) => await _userManager.CreateAsync(user, password);

        public IQueryable<User> List() => _userManager.Users;

        public async Task<User> FindByEmailAsync(string email) => await _userManager.FindByEmailAsync(email);

        public async Task<User> FindByUsernameAsync(string username) => await _userManager.FindByNameAsync(username);

        public async Task<IdentityResult> ValidateAsync(IUserValidator<User> validator, User user) => await validator.ValidateAsync(_userManager, user); 
        
        public async Task<IdentityResult> AddToRoleAsync(User user, string roleName) => await _userManager.AddToRoleAsync(user, roleName);
    }
}