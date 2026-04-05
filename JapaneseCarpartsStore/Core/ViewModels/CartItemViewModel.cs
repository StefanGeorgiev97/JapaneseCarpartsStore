namespace JapaneseCarpartsStore.Core.ViewModels
{
    public class CartItemViewModel
    {
        public int PartId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
    }
}