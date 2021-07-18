using System.Threading.Tasks;
using Application.Core.DTOs.Entities;
using Application.Core.Notifications;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace API.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ControllerBase {

        private readonly IProfileService _profileservice;

        private readonly NotificationsContext _notificationsContext;

        public ProfileController(IProfileService profileservice, NotificationsContext notificationsContext){
            _profileservice = profileservice;
            _notificationsContext = notificationsContext;
        }

        [HttpGet]
        [Route("current")]
        public async Task<IActionResult> GetCurrentUserAsync(){

            var userName = User.FindFirstValue(JwtRegisteredClaimNames.UniqueName); 

            var user = await _profileservice.GetCurrentUserAsync(userName);

            return Ok(user);

        }  

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> SignOutAsync(TokenDTO token){
            
            var userName = User.FindFirstValue(claimType: JwtRegisteredClaimNames.UniqueName);

            await _profileservice.SignOutAsync(token.RefreshToken, userName);

            if (_notificationsContext.HasNotifications){
                
                var notifications = _notificationsContext.JsonNotifications;

                if (_notificationsContext.NotificationFromType(NotificationType.TOKEN_ERROR) != null)
                    Unauthorized(notifications);

                return BadRequest(notifications);   
            }

            return Ok(new {
                Authenticated = false,
                Message = "Agora você não está mais logado"
            });
        }

        /*[HttpDelete]
        [Route("delete/{username}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] string username){

            await _service.DeleteAsync(username);

            if (responseHandler.HasErrors){

                var errors = responseHandler.JsonErrors;

                if(responseHandler.ErrorFromType(ErrorType.ENTITY_NOT_FOUND) != null)
                    return NotFound(errors);

                return BadRequest(errors);
            }

            return Ok(new { message = $"{username}, a sua conta foi deletada com sucesso" } );

        } */

    }
}