using Gateway.Api.Data.Entities;
using Gateway.Api.Data.MongoDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Api.Data.Repositories.JournalsRepository {
    public class JournalEntriesRepository : IRepository<JournalEntryEntity> {
        public JournalEntriesRepository(IMongoDBService<JournalEntryEntity> mongoDBService) {
            MongoDBService = mongoDBService;
            this.MongoDBService.Init("entries");
        }

        public IMongoDBService<JournalEntryEntity> MongoDBService { get; }

        public async Task Create(JournalEntryEntity entity) {
            await MongoDBService.CreateAsync(entity);
        }

        public async Task<IEnumerable<JournalEntryEntity>> GetAll(string journalId = "") {
            return await MongoDBService.GetByPropertyAsync(nameof(journalId), journalId);
        }

        public async Task<JournalEntryEntity> GetByID(string entityID) {
            return await MongoDBService.GetByIDAsync(entityID);
        }

        public async Task Update(JournalEntryEntity entity) {
            await MongoDBService.UpdateAsync(entity);
        }
    }
}
