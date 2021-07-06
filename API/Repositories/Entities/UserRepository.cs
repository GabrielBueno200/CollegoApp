using System;
using Domain;
using System.Linq;
using System.Threading.Tasks;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Entities
{
    public class UserRepository : IUserRepository{

        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager){
            _userManager = userManager;
        }

        public async Task<IdentityResult> Create(User user) => await _userManager.CreateAsync(user, user.pass);
        
        public async Task<IdentityResult> Delete(User user) => await _userManager.DeleteAsync(user);

        public async Task<IdentityResult> Edit(User user) => await _userManager.UpdateAsync(user);

        public IQueryable<User> List() => _userManager.Users;

    }
}