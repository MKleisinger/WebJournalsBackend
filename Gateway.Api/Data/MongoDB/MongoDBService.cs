using Gateway.Api.Data.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Gateway.Api.Data.MongoDB {
    public class MongoDBService<TDoc> : IMongoDBService<TDoc> where TDoc : IDocument {
        private IMongoCollection<TDoc> Collection { get; set; }
        private IOptions<MongoDBSettings> MongoDBSettings { get; }

        public MongoDBService(IOptions<MongoDBSettings> settings) {            
            this.MongoDBSettings = settings;            
        }

        public void Init(string collection) {
            var client = new MongoClient(MongoDBSettings.Value.ConnectionURI);
            var db = client.GetDatabase(MongoDBSettings.Value.DatabaseName);
            this.Collection = db.GetCollection<TDoc>(collection);
        }

        public async Task<IEnumerable<TDoc>> GetAsync() {
            return await Collection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<TDoc> GetByIDAsync(string entityId) {
            var filter = Builders<TDoc>.Filter.Eq("Id", entityId);
            return await Collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TDoc>> GetByPropertyAsync(string propertyName, object value) {
            var filter = Builders<TDoc>.Filter.Eq(propertyName, value);
            return await Collection.Find(filter).ToListAsync();
        }

        public async Task CreateAsync(TDoc entity) {
            await Collection.InsertOneAsync(entity);
        }

        public async Task UpdateAsync(TDoc entity) {
            var filter = Builders<TDoc>.Filter.Eq("Id", entity.Id);
            await Collection.ReplaceOneAsync(filter, entity);
        }

        public async Task DeleteAsync(string entityId) {
            var filter = Builders<TDoc>.Filter.Eq("Id", entityId);
            await Collection.DeleteOneAsync(filter);
        }
    }
}
