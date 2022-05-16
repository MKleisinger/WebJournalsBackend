using System;
using System.Collections.Generic;

namespace Gateway.Api.Data.Models {
    public class JournalEntryDto {
        public string Id { get; set; }
        public string JournalId { get; set; }
        public DateTime TimeStamp { get; set; }
        public IEnumerable<JournalTagDto> Tags { get; set; }
        public string Entry { get; set; }
    }
}
