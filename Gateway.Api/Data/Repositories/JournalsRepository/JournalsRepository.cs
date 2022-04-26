using Gateway.Api.Data.Entities;
using Gateway.Api.Data.MongoDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Api.Data.Repositories.JournalsRepository {
    public class JournalsRepository : IJournalsRepository {       

        public JournalsRepository(IMongoDBService mongoDBService) {
            MongoDBService = mongoDBService;
        }
        public IMongoDBService MongoDBService { get; }

        public async Task<IEnumerable<JournalEntity>> GetJournals() {
            return await MongoDBService.GetAsync();
        }

        public async Task<JournalEntity> GetJournal(string journalID) {
            return await MongoDBService.GetByIDAsync(journalID);
        }

        public async Task CreateJournal(JournalEntity journal) {            
            await MongoDBService.CreateAsync(journal);
        }
    }
}
