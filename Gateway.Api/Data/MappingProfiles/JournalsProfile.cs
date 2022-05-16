using AutoMapper;

namespace Gateway.Api.Data.MappingProfiles {
    public class JournalsProfile : Profile {
        public JournalsProfile() {
            CreateMap<Entities.JournalEntity, Models.JournalDto>().ReverseMap();            
            CreateMap<Entities.JournalEntryEntity, Models.JournalEntryDto>().ReverseMap();
            CreateMap<Entities.JournalBulletEntity, Models.JournalBulletDto>().ReverseMap();
            CreateMap<Entities.JournalTagEntity, Models.JournalTagDto>().ReverseMap();
        }
    }
}
