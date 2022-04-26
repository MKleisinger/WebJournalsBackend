using System;
using System.Collections.Generic;

namespace Gateway.Api.Data.Entities {
    public class JournalEntryEntity {
        public DateTime TimeStamp { get; set; }
        public IEnumerable<JournalTagEntity> Tags { get; set; }
        public string Entry { get; set; }
    }
}
