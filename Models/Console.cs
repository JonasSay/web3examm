using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ConsoleApi.Models{

    public class Console{

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Release { get; set; }
        public string Manufacturer { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
    }
}