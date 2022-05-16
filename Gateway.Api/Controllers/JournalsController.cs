using AutoMapper;
using Gateway.Api.Data.Entities;
using Gateway.Api.Data.Models;
using Gateway.Api.Data.Repositories;
using Gateway.Api.Data.Repositories.JournalsRepository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gateway.Api.Controllers {
    [ApiController]
    [Route("journals")]
    public class JournalsController : ControllerBase {
        public IRepository<JournalEntity> JournalsRepository { get; }
        public IMapper Mapper { get; }

        public JournalsController(IRepository<JournalEntity> journalsRepository, IMapper mapper) {
            JournalsRepository = journalsRepository;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<JournalDto>>> GetJournals() {
            Console.WriteLine("Entered GetJournals");
            var journals = await JournalsRepository.GetAll();
            return Ok(Mapper.Map<IEnumerable<JournalEntity>, IEnumerable<JournalDto>>(journals));
        }
                
        [HttpGet("{journalId}")]        
        public async Task<ActionResult<JournalDto>> GetJournalById(string journalId) {
            Console.WriteLine("Entered GetJournal");
            var journal = await JournalsRepository.GetByID(journalId);   
            if (journal is null) {
                return NotFound();
            }

            return Ok(Mapper.Map<JournalEntity, JournalDto>(journal));
        }

        [HttpPost]
        public async Task<ActionResult<JournalEntity>> CreateJournal([FromBody] JournalDto journal) {
            Console.WriteLine("Entered CreateJournal");
            var journalEntity = Mapper.Map<JournalDto, JournalEntity>(journal);
            await JournalsRepository.Create(journalEntity);
            return CreatedAtAction(nameof(GetJournals), journalEntity);
        }

        [HttpPut]
        public async Task<ActionResult<JournalEntity>> UpdateJournal([FromBody] JournalDto journal) {            
            Console.WriteLine("Entered UpdateJournal");
            var journalEntity = Mapper.Map<JournalDto, JournalEntity>(journal);
            await JournalsRepository.Update(journalEntity);
            return Ok(journalEntity);
        }
    }
}
