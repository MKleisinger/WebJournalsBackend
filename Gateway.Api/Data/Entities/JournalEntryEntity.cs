using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Gateway.Api.Data.Entities {
    public class JournalEntryEntity : IDocument {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("journalId")]
        [JsonPropertyName("journalId")]
        public string JournalId { get; set; }

        [BsonElement("timestamp")]
        [JsonPropertyName("timeStamp")]
        public DateTime TimeStamp { get; set; }

        [BsonElement("tags")]
        [JsonPropertyName("tags")]
        public IEnumerable<JournalTagEntity> Tags { get; set; }

        [BsonElement("entry")]
        [JsonPropertyName("entry")]
        public string Entry { get; set; }
    }
}
