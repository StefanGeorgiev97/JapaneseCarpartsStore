using JapaneseCarpartsStore.Models;
using Microsoft.EntityFrameworkCore;

namespace JapaneseCarpartsStore.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<Part> Parts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Part>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);
        }
    }
}
