using JapaneseCarpartsStore.Core.Contracts;
using JapaneseCarpartsStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JapaneseCarpartsStore.Controllers
{
    [Authorize] // Only logged-in users can see their orders
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrderController(IOrderService orderService, UserManager<ApplicationUser> userManager)
        {
            _orderService = orderService;
            _userManager = userManager;
        }

        public async Task<IActionResult> MyOrders()
        {
            var userId = _userManager.GetUserId(User);

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            var orders = await _orderService.GetUserOrdersAsync(userId);
            return View(orders);
        }

        [HttpPost] // Use POST for "Buying" actions for security
        public async Task<IActionResult> Complete()
        {
            var cartIds = HttpContext.Session.Get<List<int>>("Cart");

            if (cartIds == null || !cartIds.Any())
            {
                return RedirectToAction("Index", "Part");
            }

            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login", "Account", new { area = "Identity" });
            }

            await _orderService.CreateOrderAsync(userId, cartIds);

            // Empty the cart after successful purchase
            HttpContext.Session.Remove("Cart");

            return RedirectToAction(nameof(MyOrders));
        }
    }
}