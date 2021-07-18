using Microsoft.AspNetCore.Mvc;
using Application.Core.DTOs.Entities;
using System.Threading.Tasks;
using Application.Security.Services.Interfaces;
using Application.Core.Notifications;

namespace API.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenRefresherService _tokenService;

        private readonly NotificationsContext _notificationsContext;

        public AuthController(ITokenRefresherService tokenService, NotificationsContext notificationsContext){
            _tokenService = tokenService;
            _notificationsContext = notificationsContext;
        }

        [HttpPost]
        [Route("refreshToken")]
        public async Task<IActionResult> RefreshTokenAsync([FromBody] TokenDTO tokenDTO){
        
            var authResult = await _tokenService.RefreshTokenAsync(tokenDTO.Token, tokenDTO.RefreshToken);
            
            if (_notificationsContext.HasNotifications){

                var notifications = _notificationsContext.JsonNotifications;

                if (_notificationsContext.NotificationFromType(NotificationType.TOKEN_ERROR) != null)
                    return Unauthorized(notifications);

                return BadRequest(notifications);
            
            }

            return Ok(authResult);
        }
        
    }
}