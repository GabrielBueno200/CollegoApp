using Domain.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Services.ExternalMongoServices
{
    public class MongoDbClient : IMongoDbClient {

        private readonly IMongoCollection<University> _universities;

        public MongoDbClient(IOptions<MongoDbSettings> settings){

            var DatabaseName = settings.Value.DatabaseName;
            var URI = settings.Value.ConnectionString;

            var DatabaseClient = new MongoClient(URI);
            var Database = DatabaseClient.GetDatabase(DatabaseName);

            _universities = Database.GetCollection<University>("universities");
            
        }

        public IMongoCollection<University> GetUniversitiesCollection() => _universities;
    }
}