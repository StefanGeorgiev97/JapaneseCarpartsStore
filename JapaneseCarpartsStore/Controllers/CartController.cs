using JapaneseCarpartsStore.Core.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JapaneseCarpartsStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IPartService _partService;
        private readonly IOrderService _orderService;

        public CartController(IPartService partService, IOrderService orderService)
        {
            _partService = partService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var cartIds = HttpContext.Session.Get<List<int>>("Cart") ?? new List<int>();
            var parts = await _partService.GetPartsByIdsAsync(cartIds);
            return View(parts);
        }

        [HttpPost]
        public IActionResult Add(int id)
        {
            var cartIds = HttpContext.Session.Get<List<int>>("Cart") ?? new List<int>();
            if (!cartIds.Contains(id)) cartIds.Add(id);
            HttpContext.Session.Set("Cart", cartIds);
            return RedirectToAction("Index");
        }
    }
}