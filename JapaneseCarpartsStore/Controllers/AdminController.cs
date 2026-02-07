using JapaneseCarpartsStore.Data;
using JapaneseCarpartsStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JapaneseCarpartsStore.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Admin/Index
        public async Task<IActionResult> Index()
        {
            //We include VehicleModel and Brand so we can show the brand and model next to the part name
            var parts = await _context.Parts
                .Include(p => p.VehicleModel)
                .ThenInclude(vm => vm.Brand)
                .ToListAsync();

            return View(parts);
        }
        //GET: Admin/Create
        public IActionResult Create()
        {
            //We need a list of Vehicle Models for the dropdown
            //Format the text to show "Honda Civic (2016-2021)"
            ViewData["VehicleModelId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.VehicleModels.Include(m => m.Brand)
                .Select(m => new {
                    Id = m.Id,
                    DisplayText = $"{m.Brand.Name} {m.Name} ({m.YearStart}-{m.YearEnd})"
                }),
                "Id", "DisplayText");

            return View();
        }

        //POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,ImageUrl,Category,VehicleModelId")] Part part)
        {
            if (ModelState.IsValid)
            {
                _context.Add(part);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            //If validation fails, reload the dropdown so the form doesn't break
            ViewData["VehicleModelId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.VehicleModels.Include(m => m.Brand)
                .Select(m => new {
                    Id = m.Id,
                    DisplayText = $"{m.Brand.Name} {m.Name} ({m.YearStart}-{m.YearEnd})"
                }),
                "Id", "DisplayText", part.VehicleModelId);

            return View(part);
        }
    }
}
