using System;
using System.Linq;
using Domain.Models;
using System.Threading.Tasks;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Entities
{
    public class AccountRepository : IAccountRepository{

        private readonly UserManager<User> _userManager;

        public AccountRepository(UserManager<User> userManager){
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateAsync(User user, string password) => await _userManager.CreateAsync(user, password);

        public async Task<IdentityResult> PutInStudentRoleAsync(User user) => await _userManager.AddToRoleAsync(user, "STUDENT");
        
        public async Task<IdentityResult> DeleteAsync(User user) => await _userManager.DeleteAsync(user);

        public async Task<IdentityResult> EditAsync(User user) => await _userManager.UpdateAsync(user);

        public IQueryable<User> List() => _userManager.Users;

        public async Task<User> FindByEmailAsync(string email) => await _userManager.FindByEmailAsync(email);

        public async Task<User> FindByUsernameAsync(string username) => await _userManager.FindByNameAsync(username);

        public async Task<IdentityResult> ValidateAsync(IUserValidator<User> validator, User user) => await validator.ValidateAsync(_userManager, user); 

    }
}