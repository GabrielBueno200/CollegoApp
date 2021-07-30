using Domain.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Domain.Repositories.Interfaces
{
    public interface ICourseRepository {

        Task<List<Course>> FindAsync();
 
    }
}