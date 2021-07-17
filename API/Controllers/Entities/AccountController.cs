using System.Net.Mime;
using System;
using System.Net;
using System.Linq;
using Domain.Models;
using Application.DTOs;
using Application.Utils;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController : ControllerBase {

        private readonly IAccountService _accountService;

        private readonly IMapper _mapper;

        private readonly ResponseResult responseHandler;

        public AccountController(IAccountService accountService, ResponseResult responseHandler, IMapper mapper){
            _accountService = accountService;
            _mapper = mapper;
            this.responseHandler = responseHandler;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> SingUpAsync([FromBody] UserRegisterDTO userDto){

            await _accountService.SignUpAsync(userDto);

            if (responseHandler.HasErrors){

                var errors = responseHandler.JsonErrors;

                if(responseHandler.ErrorFromType(ErrorType.NOT_AVAILABLE) != null)
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

            if (responseHandler.HasErrors){

                var errors = responseHandler.JsonErrors;

                if(responseHandler.ErrorFromType(ErrorType.ENTITY_NOT_FOUND) != null)
                    return NotFound(errors);

                if(responseHandler.ErrorFromType(ErrorType.UNPROCESSABLE) != null)
                    return UnprocessableEntity(errors);

                return BadRequest(errors);
            }

            return Ok(result);
        }

    }
}