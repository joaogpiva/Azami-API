using Azami.Models;

namespace Azami.Repositories.Interfaces
{
    public interface IEntryRepository
    {
        Task<List<EntryModel>> GetAllEntries();
        Task<EntryModel> GetById(int id);
        Task<EntryModel> AddEntry(EntryModel entry);
        Task<List<EntryModel>> GetEntriesForUser(int userId);
        Task<EntryModel> UpdateEntry(int entryId, EntryModel entry);
        Task<bool> DeleteEntry(int entryId);
    }
}
