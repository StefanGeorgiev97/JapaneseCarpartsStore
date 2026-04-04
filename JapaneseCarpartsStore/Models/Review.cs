using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JapaneseCarpartsStore.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string Comment { get; set; } = null!;

        [Range(1, 5)]
        public int Rating { get; set; } // 1 to 5 stars

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public int PartId { get; set; }
        [ForeignKey(nameof(PartId))]
        public Part Part { get; set; } = null!;

        public string UserId { get; set; } = null!;
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;
    }
}