using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IotApiDemo1.Domain.Models
{
    public class Factory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }  

        public string FactoryName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
