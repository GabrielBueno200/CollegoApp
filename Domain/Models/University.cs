using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Domain.Models
{
    [BsonIgnoreExtraElements]
    public class University {

        [BsonId]
        private ObjectId id { get; }
        
        [BsonElement("id")]
        public int Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("acronym")]
        public string Acronym { get; set; }

        [BsonElement("state")]
        public string State { get; set; }
        
    }
}