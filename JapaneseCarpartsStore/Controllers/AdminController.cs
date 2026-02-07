using JapaneseCarpartsStore.Data;
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

        //Get Admin/Index
        public async Task<IActionResult> Index()
        {
            //We include VehicleModel and Brand so we can show the brand and model next to the part name
            var parts = await _context.Parts
                .Include(p => p.VehicleModel)
                .ThenInclude(vm => vm.Brand)
                .ToListAsync();

            return View(parts);
        }
    }
}
