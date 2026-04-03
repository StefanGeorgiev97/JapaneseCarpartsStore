using JapaneseCarpartsStore.Core.Services;
using JapaneseCarpartsStore.Data;
using JapaneseCarpartsStore.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace JapaneseCarpartsStore.Tests
{
    [TestFixture]
    public class PartServiceTests
    {
        private ApplicationDbContext dbContext;
        private PartService partService;

        [SetUp]
        public void Setup()
        {
            // We use an "In Memory" database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "JapaneseStoreTestDb_" + Guid.NewGuid().ToString())
                .Options;

            dbContext = new ApplicationDbContext(options);

            // Seed a Brand and a VehicleModel so the Part has something to link to
            var brand = new Brand { Id = 1, Name = "Nissan" };
            var model = new VehicleModel { Id = 1, Name = "Skyline", BrandId = 1, Brand = brand };

            dbContext.Brands.Add(brand);
            dbContext.VehicleModels.Add(model);

            // Add 1 test part linked to model
            dbContext.Parts.Add(new Part
            {
                Id = 1,
                Name = "Turbocharger",
                Description = "High boost performance part",
                Price = 1200,
                VehicleModelId = 1,
                VehicleModel = model
            });

            dbContext.SaveChanges();

            partService = new PartService(dbContext);
        }

        [Test]
        public async Task GetAllPartsAsync_ReturnsCorrectParts_WhenSearchMatches()
        {
            // Act - Search for "Turbo"
            var result = await partService.GetAllPartsAsync("Turbo", 1, 6);

            // Assert - Was it found?
            Assert.Multiple(() =>
            {
                Assert.That(result.TotalPartsCount, Is.EqualTo(1));
                Assert.That(result.Parts.First().Name, Is.EqualTo("Turbocharger"));
                Assert.That(result.Parts.First().BrandName, Is.EqualTo("Nissan"));
            });
        }

        [Test]
        public async Task GetAllPartsAsync_ReturnsEmpty_WhenNoMatchFound()
        {
            // Act - Search for something that doesn't exist
            var result = await partService.GetAllPartsAsync("Tesla Battery", 1, 6);

            // Assert
            Assert.That(result.TotalPartsCount, Is.EqualTo(0));
            Assert.That(result.Parts, Is.Empty);
        }

        [TearDown]
        public void TearDown()
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Dispose();
        }
    }
}