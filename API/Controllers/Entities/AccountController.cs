using System.Net.Mime;
using System;
using System.Net;
using System.Linq;
using Domain.Models;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.ViewModels;
using Application.Core.DTOs;
using Application.Core.Notifications;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [AllowAnonymous]
    public class AccountController : ControllerBase {

        private readonly IAccountService _accountService;

        private readonly IMapper _mapper;

        private readonly NotificationsContext notificationsContext;

        public AccountController(IAccountService accountService, 
                                 NotificationsContext notificationsContext, 
                                IMapper mapper){
            _accountService = accountService;
            _mapper = mapper;
            this.notificationsContext = notificationsContext;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> SingUpAsync([FromBody] UserRegisterDTO userDto){

            await _accountService.SignUpAsync(userDto);

            if (notificationsContext.HasNotifications){

                var errors = notificationsContext.JsonNotifications;

                if(notificationsContext.NotificationFromType(NotificationType.NOT_AVAILABLE) != null)
                    return Conflict(errors);

                return BadRequest(errors);
            }

            var userViewModel = _mapper.Map<UserViewModel>(userDto);
        
            return Ok(userViewModel);
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> SignInAsync([FromBody] UserLoginDTO userDto){
            
            var result = await _accountService.SignInAsync(userDto);

            if (notificationsContext.HasNotifications){

                var errors = notificationsContext.JsonNotifications;

                if(notificationsContext.NotificationFromType(NotificationType.ENTITY_NOT_FOUND) != null)
                    return NotFound(errors);

                if(notificationsContext.NotificationFromType(NotificationType.UNPROCESSABLE) != null)
                    return UnprocessableEntity(errors);

                return BadRequest(errors);
            }

            return Ok(result);
        }

    }
}