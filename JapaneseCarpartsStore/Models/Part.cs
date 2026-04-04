using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseCarpartsStore.Models
{
    public enum PartCategory
    {
        Body,
        Mechanical,
        Cooling,
        Interior,
        Electrical
    }
    public class Part
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Part name is mandatory.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters.")]
        public required string Name { get; set; }

        [Required]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "Description is too short.")]
        public required string Description { get; set; }

        [Range(0.01, 50000.00, ErrorMessage = "Price must be a positive value between 0.01 and 50,000.00")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Url(ErrorMessage = "Please provide a valid Image URL.")]
        public string? ImageUrl { get; set; }

        public int VehicleModelId { get; set; }

        [ForeignKey(nameof(VehicleModelId))]
        public VehicleModel? VehicleModel { get; set; }

        public PartCategory Category { get; set; }

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
