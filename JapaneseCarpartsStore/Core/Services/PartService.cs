using JapaneseCarpartsStore.Core.Contracts;
using JapaneseCarpartsStore.Core.ViewModels;
using JapaneseCarpartsStore.Data;
using JapaneseCarpartsStore.Models;
using Microsoft.EntityFrameworkCore;

namespace JapaneseCarpartsStore.Core.Services
{
    public class PartService : IPartService
    {
        private readonly ApplicationDbContext _context;

        public PartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AllPartsQueryModel> GetAllPartsAsync(string? searchTerm = null, int currentPage = 1, int partsPerPage = 6)
        {
            var partsQuery = _context.Parts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                partsQuery = partsQuery.Where(p =>
                    p.Name.Contains(searchTerm) ||
                    p.Description.Contains(searchTerm) ||
                    p.VehicleModel.Name.Contains(searchTerm));
            }

            var totalParts = await partsQuery.CountAsync();

            var parts = await partsQuery
                .Include(p => p.VehicleModel)
                    .ThenInclude(vm => vm.Brand)
                .OrderByDescending(p => p.Id) // Show newest parts first
                .Skip((currentPage - 1) * partsPerPage)
                .Take(partsPerPage)
                .Select(p => new PartAllViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    BrandName = p.VehicleModel.Brand.Name,
                    ModelName = p.VehicleModel.Name
                })
                .ToListAsync();

            return new AllPartsQueryModel
            {
                TotalPartsCount = totalParts,
                Parts = parts,
                SearchTerm = searchTerm,
                CurrentPage = currentPage
            };
        }

        public async Task<Part?> GetPartDetailsAsync(int id)
        {
            return await _context.Parts
                .Include(p => p.VehicleModel)
                    .ThenInclude(vm => vm.Brand)
                .Include(p => p.Reviews)
                    .ThenInclude(r => r.User) // Include user so we see who reviewed it
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}