using JapaneseCarpartsStore.Core.Contracts;
using JapaneseCarpartsStore.Core.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JapaneseCarpartsStore.Controllers
{
    public class PartController : Controller
    {
        private readonly IPartService _partService;

        public PartController(IPartService partService)
        {
            _partService = partService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] AllPartsQueryModel query)
        {
            // Ensure CurrentPage is at least 1
            int pageNumber = query.CurrentPage < 1 ? 1 : query.CurrentPage;

            // Get results from service (search term + page info)
            var serviceResult = await _partService.GetAllPartsAsync(
                query.SearchTerm,
                pageNumber,
                AllPartsQueryModel.PartsPerPage);

            // Sync QueryModel with the results for the View
            query.TotalPartsCount = serviceResult.TotalPartsCount;
            query.Parts = serviceResult.Parts;
            query.CurrentPage = pageNumber;

            return View(query);
        }

        // Details for public viewing
        public async Task<IActionResult> Details(int id)
        {
            var part = await _partService.GetPartDetailsAsync(id);
            if (part == null) return RedirectToAction("Error404", "Error");
            return View(part);
        }
    }
}