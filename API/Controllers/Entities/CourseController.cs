using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers.Entities
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase{

        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService){
            _courseService = courseService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("find")]
        public async Task<IActionResult> FindAsync(){

            var courses = await _courseService.FindAsync();

            return Ok(courses);

        }
    }
}