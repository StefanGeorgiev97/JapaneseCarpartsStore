namespace JapaneseCarpartsStore.Core.ViewModels
{
    public class PartAllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string BrandName { get; set; } = null!;
        public string ModelName { get; set; } = null!;
    }
}
