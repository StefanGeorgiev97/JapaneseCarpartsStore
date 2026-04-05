using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseCarpartsStore.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;
        public int PartId { get; set; }
        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; } = null!;
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }
    }
}