using Azami.Data;
using Azami.Models;
using Azami.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Azami.Repositories
{
    public class EntryRepository : IEntryRepository
    {
        private AzamiDbContext _dbContext;
        public EntryRepository(AzamiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EntryModel> GetById(int id)
        {
            EntryModel? entry = await _dbContext.Entries.FirstOrDefaultAsync(e => e.Id == id);
            return entry;
        }

        public async Task<List<EntryModel>> GetAllEntries()
        {
            return await _dbContext.Entries.ToListAsync();
        }

        public async Task<EntryModel> AddEntry(EntryModel entry)
        {
            UserModel? user = await _dbContext.Users.FindAsync(entry.UserId);

            if (user == null)
            {
                throw new Exception("Related user not found");
            }

            await _dbContext.AddAsync(entry);
            await _dbContext.SaveChangesAsync();
            return entry;
        }

        public async Task<List<EntryModel>> GetEntriesForUser(int userId)
        {
            return await _dbContext.Entries.Where(e => e.UserId == userId).ToListAsync();
        }

        public async Task<EntryModel> UpdateEntry(int entryId, EntryModel entry)
        {
            EntryModel? entryToUpdate = await _dbContext.Entries.FindAsync(entryId);
            if (entryToUpdate == null)
            {
                throw new Exception("Entry not found");
            }

            entryToUpdate.Title = entry.Title;
            entryToUpdate.Username = entry.Username;
            entryToUpdate.Password = entry.Password;

            _dbContext.Update(entryToUpdate);
            await _dbContext.SaveChangesAsync();
            return entryToUpdate;

        }

        public async Task<bool> DeleteEntry(int entryId)
        {
            EntryModel? entryToDelete = await _dbContext.Entries.FindAsync(entryId);

            if (entryToDelete == null) {
                throw new Exception("Entry not found");
            }

            _dbContext.Remove(entryToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
