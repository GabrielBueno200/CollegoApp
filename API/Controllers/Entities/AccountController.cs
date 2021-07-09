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

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class AccountController : ControllerBase {

        private readonly IAccountService _service;

        private readonly IMapper _mapper;

        private readonly ResponseResult responseHandler;

        public AccountController(IAccountService service, ResponseResult responseHandler, IMapper mapper){
            _service = service;
            _mapper = mapper;
            this.responseHandler = responseHandler;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] UserRegisterDTO userDto){

            await _service.CreateAsync(userDto);

            if (responseHandler.HasErrors){
                var errors = responseHandler.JsonErrors;
            
                if (responseHandler.EntityNotFound == null)
                    return NotFound(errors);

                return BadRequest(errors);
            }

            var newUser = _mapper.Map<User>(userDto);
            var userViewModel = _mapper.Map<UserViewModel>(newUser);
        
            return Ok(userViewModel);
        }
    }
}