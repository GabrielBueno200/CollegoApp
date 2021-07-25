using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Services.Interfaces
{
    public interface IUniversityService {

        Task<List<University>> FindByAcronymAsync(string acronym);
         
    }
}