using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Services.Interfaces;
using Domain.Models;
using Domain.Repositories.Interfaces;

namespace Application.Services.Entities
{
    public class UniversityService : IUniversityService{

        private readonly IUniversityRepository _universityRepository;

        public UniversityService(IUniversityRepository universityRepository){
            _universityRepository = universityRepository;
        }

        public Task<List<University>> FindByAcronymAsync(string acronym){
            
            return _universityRepository.FindByAcronymAsync(acronym);

        }

    }
}