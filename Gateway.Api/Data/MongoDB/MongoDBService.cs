using Gateway.Api.Data.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Gateway.Api.Data.MongoDB {
    public class MongoDBService : IMongoDBService {
        private readonly IMongoCollection<JournalEntity> journalsCollection;

        public MongoDBService(IOptions<MongoDBSettings> settings) {
            var client = new MongoClient(settings.Value.ConnectionURI);
            var db = client.GetDatabase(settings.Value.DatabaseName);
            this.journalsCollection = db.GetCollection<JournalEntity>(settings.Value.CollectionName);
        }

        public async Task<IEnumerable<JournalEntity>> GetAsync() {
            return await journalsCollection.Find(new BsonDocument()).ToListAsync();
        }
        public async Task<JournalEntity> GetByIDAsync(string journalID) {
            var filter = Builders<JournalEntity>.Filter.Eq("JournalID", journalID);
            return await journalsCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(JournalEntity journal) {
            await journalsCollection.InsertOneAsync(journal);
        }

        public async Task AddToJournalAsync(string journalId, string entryId) { }
        public async Task DeleteAsync(string journalId) { }
    }
}
