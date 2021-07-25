using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Repositories.Interfaces
{
    public interface IUniversityRepository {

        Task<List<University>> FindByAcronymAsync(string acronym);
        
    }
}