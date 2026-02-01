using System.ComponentModel.DataAnnotations;

namespace JapaneseCarpartsStore.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; } //Toyota, Honda or Mazda

        public string? ImageUrl { get; set; } //Logo

        //Navigation Property: One Brand has many Models
        public ICollection<VehicleModel> VehicleModels { get; set; } = new List<VehicleModel>();
    }
}
