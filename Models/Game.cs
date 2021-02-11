using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GameApi.Models{

    public class Game{

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Platform { get; set; }
        public int Pegi { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }
    }
}