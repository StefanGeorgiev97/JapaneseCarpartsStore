using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseCarpartsStore.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Name { get; set; } //Civic, RAV-4, CX-3 etc.

        [Range(1900, 2100)]
        public int YearStart { get; set; }

        [Range(1900, 2100)]
        public int YearEnd { get; set; }

        //Foreign Key for Brand
        public int BrandId { get; set; }

        [ForeignKey(nameof(BrandId))]
        public Brand? Brand { get; set; }

        //Navigation Property: One Model has many Parts
        public ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}
