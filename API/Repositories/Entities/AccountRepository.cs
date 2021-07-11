using System;
using System.Linq;
using Domain.Models;
using System.Threading.Tasks;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.Entities
{
    public class AccountRepository : IAccountRepository {

        private readonly IUserRepository _userRepository;

        public AccountRepository(IUserRepository userRepository){
            _userRepository = userRepository;
        }

        public async Task SignUpAsync(User user, string password) => await _userRepository.CreateAsync(user, password);
    }
}