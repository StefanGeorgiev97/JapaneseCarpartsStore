using JapaneseCarpartsStore.Core.Contracts;
using JapaneseCarpartsStore.Data;
using JapaneseCarpartsStore.Models;
using Microsoft.EntityFrameworkCore;

namespace JapaneseCarpartsStore.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;
        public OrderService(ApplicationDbContext context) => _context = context;

        public async Task CreateOrderAsync(string userId, List<int> partIds)
        {
            var parts = await _context.Parts.Where(p => partIds.Contains(p.Id)).ToListAsync();
            var order = new Order { UserId = userId, TotalPrice = parts.Sum(p => p.Price) };
            foreach (var part in parts)
            {
                order.OrderItems.Add(new OrderItem { PartId = part.Id, Quantity = 1, PriceAtPurchase = part.Price });
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Order>> GetUserOrdersAsync(string userId)
        {
            return await _context.Orders.Include(o => o.OrderItems).ThenInclude(oi => oi.Part).Where(o => o.UserId == userId).ToListAsync();
        }
    }
}