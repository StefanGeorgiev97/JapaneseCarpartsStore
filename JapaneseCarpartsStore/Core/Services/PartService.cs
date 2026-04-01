using Microsoft.EntityFrameworkCore;
using JapaneseCarpartsStore.Data;
using JapaneseCarpartsStore.Models;
using JapaneseCarpartsStore.Core.Contracts;

namespace JapaneseCarpartsStore.Core.Services
{
    public class PartService : IPartService
    {
        private readonly ApplicationDbContext _context;

        public PartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Part>> GetAllPartsAsync(string? searchTerm = null)
        {
            var query = _context.Parts
                .Include(p => p.VehicleModel)
                    .ThenInclude(vm => vm.Brand)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                string normalizedSearch = searchTerm.ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(normalizedSearch) ||
                                        p.Description.ToLower().Contains(normalizedSearch));
            }

            return await query.ToListAsync();
        }
    }
}