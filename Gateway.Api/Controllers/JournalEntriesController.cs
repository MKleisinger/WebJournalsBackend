using AutoMapper;
using Gateway.Api.Data.Entities;
using Gateway.Api.Data.Models;
using Gateway.Api.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Api.Controllers {
    [ApiController]
    [Route("entries")]
    public class JournalEntriesController : ControllerBase {
        public IRepository<JournalEntryEntity> EntriesRepository { get; }
        public IMapper Mapper { get; }

        public JournalEntriesController(IRepository<JournalEntryEntity> entriesRepository, IMapper mapper) {
            EntriesRepository = entriesRepository;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JournalEntryDto>>> GetAllForJournal([FromQuery]string journalId) {
            if(string.IsNullOrWhiteSpace(journalId)) {
                return BadRequest();
            }

            var entries = await EntriesRepository.GetAll(journalId);
            return Ok(Mapper.Map<IEnumerable<JournalEntryEntity>, IEnumerable<JournalEntryDto>>(entries));
        }
         
        [HttpGet("{entryId}")]
        public async Task<ActionResult<JournalEntryDto>> GetEntry(string entryId) {
            if (string.IsNullOrWhiteSpace(entryId)) {
                return BadRequest();
            }

            var entry = await EntriesRepository.GetByID(entryId);
            if (entry is null) {
                return NotFound();
            }

            return Ok(Mapper.Map<JournalEntryEntity, JournalEntryDto>(entry));
        }

        [HttpPost]
        public async Task<ActionResult<JournalEntryEntity>> CreateEntry([FromBody] JournalEntryDto entry) {
            if(string.IsNullOrWhiteSpace(entry.JournalId)) {
                return BadRequest();
            }

            var entryEntity = Mapper.Map<JournalEntryDto, JournalEntryEntity>(entry);
            await EntriesRepository.Create(entryEntity);
            return CreatedAtAction(nameof(GetAllForJournal), entryEntity);
        }

        [HttpPut]
        public async Task<ActionResult<JournalEntryEntity>> UpdateEntry([FromBody] JournalEntryDto entry) {
            if(string.IsNullOrWhiteSpace(entry.Id) || string.IsNullOrWhiteSpace(entry.JournalId)) {
                return BadRequest();
            }

            var entryEntity = Mapper.Map<JournalEntryDto, JournalEntryEntity>(entry);
            await EntriesRepository.Update(entryEntity);
            return Ok(entryEntity);
        }
    }
}
