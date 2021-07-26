using Domain.Models;
using MongoDB.Driver;

namespace Infrastructure.Services.ExternalMongoServices{
    public interface IMongoDbClient{

        

        IMongoCollection<University> GetUniversitiesCollection();
    }
}