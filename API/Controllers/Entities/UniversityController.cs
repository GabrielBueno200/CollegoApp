using System.Threading.Tasks;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class UniversityController : ControllerBase {
        
        private readonly IUniversityService _universityService;

        public UniversityController(IUniversityService universityService){
            _universityService = universityService;
        }

        [HttpGet]
        [Route("findByAcronym")]
        public async Task<IActionResult> FindByAcronym([FromRoute] string acronym){
            
            var universities = await _universityService.FindByAcronymAsync(acronym);

            return Ok(universities);

        } 
    }
}