using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Application.Core.Notifications;
using Domain.Repositories.Interfaces;
using Application.Services.Interfaces;
using Application.Security.Entities;
using Application.Security.Services.Interfaces;

namespace Application.Security.Services.Entities
{
    public class TokenRefresherService : ITokenRefresherService
    {

        private readonly TokenValidationParameters _JwtValidationParams;

        private readonly IRefreshTokenRepository _tokenRepository;

        private readonly ITokenGeneratorService _tokenGeneratorService;

        private readonly IUserRepository _userRepository;

        private readonly NotificationsContext _notificationsContext;

        public TokenRefresherService(TokenValidationParameters JwtValidationParams,
                                     NotificationsContext notificationsContext,
                                     IRefreshTokenRepository tokenRepository,
                                     ITokenGeneratorService tokenGeneratorService,
                                     IUserRepository userRepository){
            _JwtValidationParams = JwtValidationParams;
            _notificationsContext = notificationsContext;
            _tokenRepository = tokenRepository;
            _userRepository = userRepository;
            _tokenGeneratorService = tokenGeneratorService;
        }

        public async Task<AuthenticationResult> RefreshTokenAsync(string accessToken, string refreshToken){

            var validatedToken = GetPrincipalFromToken(accessToken);

            if (validatedToken == null)
                return null;

            # region Access Token Validation
            
            //exp secs
            var expiryDateUnix = long.Parse(
                validatedToken.FindFirstValue(claimType: JwtRegisteredClaimNames.Exp)
            );

            var expiryToUTCDateTime = 
                new DateTime(1970, 1, 1, 0, 0, 0).ToUniversalTime()
                .AddSeconds(expiryDateUnix);
            
            if (expiryToUTCDateTime > DateTime.UtcNow){
                _notificationsContext.AddNotification("O token informado ainda não está expirado!", NotificationType.TOKEN_ERROR);
                return null;
            }

            # endregion

            # region Refresh Token Validation

            var DbStoredRFToken = await _tokenRepository.FindByTokenAsync(refreshToken);

            if (DbStoredRFToken == null){
                _notificationsContext.AddNotification("O refresh token informado já foi utilizado ou não existe!", NotificationType.TOKEN_ERROR);
                return null;
            }

            var userAccessTokenId = validatedToken.FindFirstValue(claimType: JwtRegisteredClaimNames.Sub);

            if (DbStoredRFToken.UserId != userAccessTokenId){
                _notificationsContext.AddNotification("Os tokens informados não pertencem ao mesmo usuário!", NotificationType.TOKEN_ERROR);
                return null;
            }

            # endregion

            # region Refresh Token Register

            await _tokenRepository.DeleteAsync(DbStoredRFToken.Token);

            var user = await _userRepository.FindByIdAsync(DbStoredRFToken.UserId);

            return await _tokenGeneratorService.GenerateTokenAsync(user);

            # endregion
        }


        private ClaimsPrincipal GetPrincipalFromToken(string accessToken){
            
            var tokenHandler = new JwtSecurityTokenHandler();

            var principal = 
                tokenHandler.ValidateToken(accessToken, _JwtValidationParams, out SecurityToken validatedToken);

            if (principal == null){
                _notificationsContext.AddNotification("O Token informado não é válido!", NotificationType.TOKEN_ERROR);
                return null;
            };

            if (!IsUsingValidAlgorithmSecurity(validatedToken as JwtSecurityToken)){
                _notificationsContext.
                    AddNotification("O algoritmo utilizado pelo token informado não é correspondente!", NotificationType.TOKEN_ERROR);
                return null;
            }

            return principal;

        }

        private bool IsUsingValidAlgorithmSecurity(JwtSecurityToken securityToken){

            var tokenAlgorithm = securityToken.Header.Alg;
            
            return tokenAlgorithm.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
        }
    
    }
}