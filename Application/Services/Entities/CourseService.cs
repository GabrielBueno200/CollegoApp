using Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.Repositories.Interfaces;
using Application.Services.Interfaces;

namespace Application.Services.Entities
{
    public class CourseService : ICourseService {
        
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository){
            _courseRepository = courseRepository;
        }

        public async Task<List<Course>> FindAsync() => await _courseRepository.FindAsync();

    }
}