using Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories.Interfaces;

namespace Infrastructure.Repositories.Entities
{
    public class CourseRepository : ICourseRepository {

        private readonly DataContext _context;

        public CourseRepository(DataContext context){
            _context = context;
        }

        public async Task<List<Course>> FindAsync() => await _context.Course.ToListAsync();

    }
}