using Gateway.Api.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Api.Data.MongoDB {
    public interface IMongoDBService {
        Task<IEnumerable<JournalEntity>> GetAsync();
        Task<JournalEntity> GetByIDAsync(string journalID);
        Task CreateAsync(JournalEntity journal);
        Task AddToJournalAsync(string journalId, string entryId);
        Task DeleteAsync(string journalId);

    }
}
