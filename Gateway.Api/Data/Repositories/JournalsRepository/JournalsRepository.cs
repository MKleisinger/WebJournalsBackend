using Gateway.Api.Data.Entities;
using Gateway.Api.Data.MongoDB;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Api.Data.Repositories.JournalsRepository {
    public class JournalsRepository : IRepository<JournalEntity> {       

        public JournalsRepository(IMongoDBService<JournalEntity> mongoDBService) {
            MongoDBService = mongoDBService;
            this.MongoDBService.Init("journals");
        }
        public IMongoDBService<JournalEntity> MongoDBService { get; }

        public async Task<IEnumerable<JournalEntity>> GetAll(string id = "") {
            return await MongoDBService.GetAsync();
        }

        public async Task<JournalEntity> GetByID(string journalID) {
            return await MongoDBService.GetByIDAsync(journalID);
        }

        public async Task Create(JournalEntity journal) {            
            await MongoDBService.CreateAsync(journal);
        }

        public async Task Update(JournalEntity journal) {
            await MongoDBService.UpdateAsync(journal);
        }
    }
}
