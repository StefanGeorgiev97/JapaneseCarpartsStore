using JapaneseCarpartsStore.Models;

namespace JapaneseCarpartsStore.Core.Contracts
{
    public interface IPartService
    {
        Task<IEnumerable<Part>> GetAllPartsAsync(string? searchTerm = null); // Updated for search function
    }
}