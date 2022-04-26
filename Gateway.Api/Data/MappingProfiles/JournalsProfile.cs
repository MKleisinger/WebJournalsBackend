using AutoMapper;

namespace Gateway.Api.Data.MappingProfiles {
    public class JournalsProfile : Profile {
        public JournalsProfile() {
            CreateMap<Entities.JournalEntity, Models.JournalDto>();
            CreateMap<Models.JournalDto, Entities.JournalEntity>();
            CreateMap<Entities.JournalEntryEntity, Models.JournalEntryDto>();            
        }
    }
}
