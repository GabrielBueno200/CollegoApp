using System;
using System.Linq;
using Domain.Models;
using System.Threading.Tasks;
using Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Repositories.Entities
{
    public class AccountRepository : IAccountRepository {

        private readonly IUserRepository _userRepository;

        private readonly SignInManager<User> _signInManager;

        public AccountRepository(IUserRepository userRepository, SignInManager<User> signInManager){
            _userRepository = userRepository;
            _signInManager = signInManager;
        }

        public async Task SignUpAsync(User user, string password) => await _userRepository.CreateAsync(user, password);
    
        public async Task<SignInResult> SignInAsync(User user, string password) => await _signInManager.PasswordSignInAsync(user, password, false, true);
    
        public async Task SignOutAsync() => await _signInManager.SignOutAsync();

    }
}