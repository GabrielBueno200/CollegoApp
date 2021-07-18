using System.Threading.Tasks;
using Domain.Repositories.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories.Entities
{
    public class ProfileRepository : IProfileRepository {

        private readonly SignInManager<User> _signInManager;

        public ProfileRepository(SignInManager<User> signInManager){
            _signInManager = signInManager;
        }

        public Task<IdentityResult> DeleteAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> EditAsync(User user)
        {
            throw new System.NotImplementedException();
        }

        public async Task SignOutAsync() => await _signInManager.SignOutAsync();
    }
}