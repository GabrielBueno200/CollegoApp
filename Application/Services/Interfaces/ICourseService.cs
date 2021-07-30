using Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Application.Services.Interfaces
{
    public interface ICourseService {

        Task<List<Course>> FindAsync();
         
    }
}