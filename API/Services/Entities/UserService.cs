using System.Threading.Tasks;
using API.Repositories.Interfaces;
using API.Services.Interfaces;
using API.Utils;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Services.Entities
{
    public class UserService : IUserService {

        private readonly IUserRepository _userRepository;
        
        private readonly IUserValidator<User> _userValidator;
        
        private readonly ResponseResult responseHandler;

        public UserService(IUserRepository userRepository, ResponseResult responseHandler){
            _userRepository = userRepository;
            this.responseHandler = responseHandler;
        }

        public async Task<bool> IsEmailAvailable(string email){
            var isEmailAvailable = (await _userRepository.FindByEmailAsync(email)) == null;
            
            if (!isEmailAvailable)
                responseHandler.AddError("Endereço de e-mail já cadastrado!", ErrorType.NOT_AVAILABLE);
                        
            return isEmailAvailable;
        }
        public async Task<bool> IsUsernameAvailable(string username){
            var isUsernameAvailable = (await _userRepository.FindByUsernameAsync(username)) == null ;
            
            if (!isUsernameAvailable)
                responseHandler.AddError("Username já cadastrado!", ErrorType.NOT_AVAILABLE);

            return isUsernameAvailable;
        }

        public async Task AddToRoleAsync(User user, string roleName) => await _userRepository.AddToRoleAsync(user, roleName); 
        
        public async Task<IdentityResult> ValidateAsync(User user) => await _userRepository.ValidateAsync(_userValidator, user);
    }
}