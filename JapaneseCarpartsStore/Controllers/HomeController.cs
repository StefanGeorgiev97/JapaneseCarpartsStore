using JapaneseCarpartsStore.Data;
using JapaneseCarpartsStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JapaneseCarpartsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index(int? selectedBrandId, int? selectedModelId)
        {
            var viewModel = new HomeIndexViewModel();

            // 1 - Load Brands
            viewModel.Brands = new SelectList(_context.Brands, "Id", "Name", selectedBrandId);
            viewModel.SelectedBrandId = selectedBrandId;
            viewModel.SelectedModelId = selectedModelId;

            // 2 - If a Brand is selected, load its Models
            if (selectedBrandId.HasValue)
            {
                var models = await _context.VehicleModels
                    .Where(m => m.BrandId == selectedBrandId.Value)
                    .Select(m => new
                    {
                        Id = m.Id,
                        DisplayText = $"{m.Name} ({m.YearStart}-{m.YearEnd})"
                    })
                    .ToListAsync();

                viewModel.VehicleModels = new SelectList(models, "Id", "DisplayText", selectedModelId);
            }

            // 3 - If a Model is selected, load its Parts and Image
            if (selectedModelId.HasValue)
            {
                var selectedModel = await _context.VehicleModels.FindAsync(selectedModelId.Value);
                if (selectedModel != null)
                {
                    ViewData["SelectedModelImage"] = selectedModel.ImageUrl;
                    ViewData["SelectedModelName"] = selectedModel.Name;
                }

                viewModel.Parts = await _context.Parts
                    .Include(p => p.VehicleModel)
                    .Where(p => p.VehicleModelId == selectedModelId.Value)
                    .ToListAsync();
            }

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}