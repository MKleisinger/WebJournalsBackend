using System.Collections.Generic;

namespace Gateway.Api.Data.Models {
    public class JournalDto {
        public string JournalID { get; set; }
        public string Title { get; set; }
        public IEnumerable<JournalEntryDto> Entries { get; set; }
    }
}
