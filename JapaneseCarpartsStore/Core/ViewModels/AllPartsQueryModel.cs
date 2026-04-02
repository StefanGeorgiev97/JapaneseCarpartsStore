namespace JapaneseCarpartsStore.Core.ViewModels
{
    public class AllPartsQueryModel
    {
        public const int PartsPerPage = 6;
        public string? SearchTerm { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalPartsCount { get; set; }
        public IEnumerable<PartAllViewModel> Parts { get; set; } = new List<PartAllViewModel>();
    }
}
