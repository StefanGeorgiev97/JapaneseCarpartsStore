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

        [Required]
        [StringLength(100)]
        public required string Name { get; set; } //Radiator, Bumper, Headlamp

        [Required]
        [StringLength(500)]
        public required string Description { get; set; }

        [Range(0.01, 10000.00)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public PartCategory Category { get; set; }

        // Foreign Key for VehicleModel
        public int VehicleModelId { get; set; }

        [ForeignKey(nameof(VehicleModelId))]
        public VehicleModel? VehicleModel { get; set; }
    }
}
