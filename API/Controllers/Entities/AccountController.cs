using System;
using System.Net;
using System.Linq;
using Domain.Models;
using Domain.DTOs;
using API.Utils;
using System.Threading.Tasks;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.ViewModels;
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

        public async Task<IActionResult> SignInAsync([FromBody] UserLoginDTO userDto){
            throw new NotImplementedException();
        }

    }
}