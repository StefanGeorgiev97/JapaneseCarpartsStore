using JapaneseCarpartsStore.Models;

namespace JapaneseCarpartsStore.Core.Contracts
{
    public interface IOrderService
    {
        Task CreateOrderAsync(string userId, List<int> partIds);
        Task<IEnumerable<Order>> GetUserOrdersAsync(string userId);
    }
}