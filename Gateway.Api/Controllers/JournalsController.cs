using AutoMapper;
using Gateway.Api.Data.Entities;
using Gateway.Api.Data.Models;
using Gateway.Api.Data.Repositories.JournalsRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Api.Controllers {
    [ApiController]
    [Route("journals")]
    public class JournalsController : ControllerBase {
        public IJournalsRepository JournalsRepository { get; }
        public IMapper Mapper { get; }

        public JournalsController(IJournalsRepository journalsRepository, IMapper mapper) {
            JournalsRepository = journalsRepository;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JournalDto>>> GetJournals() {
            var journals = await JournalsRepository.GetJournals();
            return Ok(Mapper.Map<IEnumerable<JournalEntity>, IEnumerable<JournalDto>>(journals));
        }

        
        [HttpGet("{journalID}")]        
        public async Task<ActionResult<JournalDto>> GetJournalById(string journalID) {
            var journal = await JournalsRepository.GetJournal(journalID);   
            if (journal is null) {
                return NotFound();
            }

            return Ok(Mapper.Map<JournalEntity, JournalDto>(journal));
        }

        [HttpPost]
        public async Task<IActionResult> CreateJournal([FromBody] JournalDto journal) {
            await JournalsRepository.CreateJournal(Mapper.Map<JournalDto, JournalEntity>(journal));
            return CreatedAtAction(nameof(GetJournals), journal);
        }
    }
}
