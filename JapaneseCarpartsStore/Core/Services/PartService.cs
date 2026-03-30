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

        public async Task<IEnumerable<Part>> GetAllPartsAsync()
        {
            return await _context.Parts
                .Include(p => p.VehicleModel)
                    .ThenInclude(vm => vm.Brand)
                .ToListAsync();
        }
    }
}