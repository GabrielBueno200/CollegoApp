using System.Net;
using System.Linq;
using Domain;
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

        public AccountController(IAccountService service, IMapper mapper){
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] UserRegisterDTO userDto){

            var result = await _service.Create(userDto);

            if (result.HasErrors)
                return BadRequest(result.JsonErrors);

            var newUser = _mapper.Map<User>(userDto);
            var userViewModel = _mapper.Map<UserViewModel>(newUser);
        
            return Ok(userViewModel);
        }

        [HttpGet]
        [Route("teste")]
        public async Task<IActionResult> Teste(){
            return Ok("{eita}");
        }

        

        
    }
}