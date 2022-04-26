using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gateway.Api.Data.Entities {
    public class JournalEntity {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string JournalID { get; set; }

        [BsonElement("title")]
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [BsonElement("subject")]
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [BsonElement("bullets")]
        [JsonPropertyName("bullets")]
        public IEnumerable<JournalBulletEntity> Bullets { get; set; }

        [BsonElement("entries")]
        [JsonPropertyName("entries")]
        public IEnumerable<JournalEntryEntity> Entries { get; set; }
    }
}
