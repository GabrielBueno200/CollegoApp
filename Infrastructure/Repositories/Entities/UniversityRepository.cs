using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Repositories.Interfaces;
using Infrastructure.Services.ExternalMongoServices;
using MongoDB.Driver;

namespace Infrastructure.Repositories.Entities
{
    public class UniversityRepository : IUniversityRepository {

        private readonly IMongoCollection<University> _context;
        
        public UniversityRepository(MongoDbClient dbClient){
            _context = dbClient.GetUniversitiesCollection();
        }

        public async Task<List<University>> FindByAcronymAsync(string acronym) 
            => (await _context.FindAsync(x => x.Acronym == acronym)).ToList();

    }
}