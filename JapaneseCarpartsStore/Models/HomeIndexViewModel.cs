using Microsoft.AspNetCore.Mvc.Rendering;

namespace JapaneseCarpartsStore.Models
{
    public class HomeIndexViewModel
    {
        //For the dropdown menus
        public SelectList? Brands { get; set; }
        public SelectList? VehicleModels { get; set; }

        //Capturing user selection
        public int? SelectedBrandId { get; set; }
        public int? SelectedModelId { get; set; }

        //Display results (Parts)
        public List<Part> Parts { get; set; } = new List<Part>();
    }
}
