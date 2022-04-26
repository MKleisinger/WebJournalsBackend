using Gateway.Api.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Api.Data.Repositories.JournalsRepository {
    public interface IJournalsRepository {
        Task<IEnumerable<JournalEntity>> GetJournals();
        Task<JournalEntity> GetJournal(string journalID);
        Task CreateJournal(JournalEntity journal);
    }
}
