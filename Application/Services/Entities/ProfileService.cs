using System;
using System.Linq;
using Domain.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using Application.ViewModels;
using Domain.Repositories.Interfaces;
using Application.Core.Notifications;
using Application.Services.Interfaces;
using AutoMapper;

namespace Application.Services.Entities
{
    public class ProfileService : IProfileService {
        
        private readonly IProfileRepository _profileRepository;

        private readonly IUserRepository _userRepository;

        private readonly IRefreshTokenRepository _tokenRepository;

        private readonly IMapper _mapper;

        private readonly NotificationsContext _notificationsContext;

        public ProfileService(IProfileRepository profileRepository, 
                              IUserRepository userRepository, 
                              IRefreshTokenRepository tokenRepository, 
                              IMapper mapper, 
                              NotificationsContext notificationsContext){
            _profileRepository = profileRepository;
            _userRepository = userRepository;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
            _notificationsContext = notificationsContext;
        }

        public async Task<UserViewModel> GetCurrentUserAsync(string username) {

            var user = await _userRepository.FindByUsernameAsync(username);

            return _mapper.Map<UserViewModel>(user);

        }

        public Task DeleteAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> EditAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public IQueryable<User> List()
        {
            throw new NotImplementedException();
        }

        public async Task SignOutAsync(string token){

            var requestedToken = await _tokenRepository.FindByTokenAsync(token);

            if (requestedToken == null){
                _notificationsContext.AddNotification("O refresh token informado não existe!", NotificationType.TOKEN_ERROR);
                return;
            }

            await _tokenRepository.DeleteAsync(token);

            await _profileRepository.SignOutAsync();

        }
    }
}