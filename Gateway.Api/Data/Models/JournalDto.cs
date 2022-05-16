using System.Collections.Generic;

namespace Gateway.Api.Data.Models {
    public class JournalDto {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Subject { get; set; }
        public IEnumerable<JournalBulletDto> Bullets { get; set; }
    }
}
