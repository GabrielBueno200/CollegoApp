using System.Net.Mime;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Domain.Models;
using Domain.Repositories.Interfaces;
using Application.Core.DTOs.Entities;
using Application.Core.Notifications;

namespace Application.Services.Entities
{
    public class ProfileService : IProfileService {
        
        private readonly IProfileRepository _profileRepository;

        private readonly IRefreshTokenRepository _tokenRepository;

        private readonly NotificationsContext _notificationsContext;

        public ProfileService(IProfileRepository profileRepository, IRefreshTokenRepository tokenRepository, NotificationsContext notificationsContext)
        {
            _profileRepository = profileRepository;
            _tokenRepository = tokenRepository;
            _notificationsContext = notificationsContext;
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