using System;
using System.Collections.Generic;

namespace Gateway.Api.Data.Models {
    public class JournalEntryDto {
        public DateTime TimeStamp { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public string Entry { get; set; }
    }
}
