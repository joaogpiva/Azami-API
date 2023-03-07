using Azami.Models;
using Azami.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Azami.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntryController : ControllerBase
    {
        private IEntryRepository _entryRepository;
        public EntryController(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<EntryModel>>> GetAllEntries()
        {
            List<EntryModel> entries = await _entryRepository.GetAllEntries();

            return Ok(entries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EntryModel>> GetEntry(int id)
        {
            EntryModel entry = await _entryRepository.GetById(id);

            return Ok(entry);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<EntryModel>>> GetEntriesForUser(int userId)
        {
            List<EntryModel> entries = await _entryRepository.GetEntriesForUser(userId);

            return Ok(entries);
        }

        [HttpPost]
        public async Task<ActionResult<EntryModel>> AddEntry([FromBody] EntryModel entry)
        {
            EntryModel addedEntry = await _entryRepository.AddEntry(entry);
            
            return Ok(addedEntry);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EntryModel>> UpdateEntry(int id, [FromBody] EntryModel entry)
        {
            EntryModel updatedEntry = await _entryRepository.UpdateEntry(id, entry);

            return Ok(updatedEntry);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteEntry(int id)
        {
            await _entryRepository.DeleteEntry(id);

            return Ok(true);
        }
    }
}
