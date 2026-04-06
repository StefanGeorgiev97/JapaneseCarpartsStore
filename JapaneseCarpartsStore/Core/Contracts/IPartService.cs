using JapaneseCarpartsStore.Core.ViewModels;
using JapaneseCarpartsStore.Models;

namespace JapaneseCarpartsStore.Core.Contracts
{
    public interface IPartService
    {
        // Returns model containing count and filtered list
        Task<AllPartsQueryModel> GetAllPartsAsync(string? searchTerm = null, int currentPage = 1, int partsPerPage = 6);

        Task<Part?> GetPartDetailsAsync(int id);

        Task<IEnumerable<Part>> GetPartsByIdsAsync(IEnumerable<int> ids);

        Task AddReviewAsync(int partId, string userId, string comment, int rating);
    }
}