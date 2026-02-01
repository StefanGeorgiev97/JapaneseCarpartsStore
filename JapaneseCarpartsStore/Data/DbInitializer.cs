using JapaneseCarpartsStore.Models;

namespace JapaneseCarpartsStore.Data
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                // Ensure database is created
                context.Database.EnsureCreated();

                // Check if data exists
                if (context.Brands.Any())
                {
                    return;
                }

                //1 - Create Brands
                var honda = new Brand { Name = "Honda", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7b/Honda_Logo.svg" };
                var toyota = new Brand { Name = "Toyota", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/9/9d/Toyota_carlogo.svg" };
                var mazda = new Brand { Name = "Mazda", ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/f/f9/Mazda_logo_with_emblem.svg" };

                context.Brands.AddRange(honda, toyota, mazda);
                context.SaveChanges();

                //2 - Create Models (With added images)
                var models = new List<VehicleModel>
                {
                    //Honda
                       new VehicleModel { Name = "Civic", YearStart = 2008, YearEnd = 2012, BrandId = honda.Id, ImageUrl = "https://s3.wheelsage.org/picture/h/honda/civic_type-r_euro/honda_civic_type-r_euro_1.jpeg" },
                       new VehicleModel { Name = "Accord", YearStart = 2002, YearEnd = 2008, BrandId = honda.Id, ImageUrl = "https://s3.wheelsage.org/picture/h/honda/accord_sedan/honda_accord_sedan_801.jpeg" },
                       new VehicleModel { Name = "CR-V", YearStart = 2011, YearEnd = 2016, BrandId = honda.Id, ImageUrl = "https://s3.wheelsage.org/picture/h/honda/cr-v/honda_cr-v386.jpeg" },

                    //Toyota
                       new VehicleModel { Name = "Corolla Hatchback", YearStart = 2012, YearEnd = 2018, BrandId = toyota.Id, ImageUrl = "https://s3.wheelsage.org/picture/t/toyota/corolla_hybrid/toyota_corolla_hybrid_4.jpeg" },
                       new VehicleModel { Name = "Hilux", YearStart = 2005, YearEnd = 2015, BrandId = toyota.Id, ImageUrl = "https://s3.wheelsage.org/picture/t/toyota/hilux_double_cab/toyota_hilux_double_cab_3.jpg" },
                       new VehicleModel { Name = "Yaris", YearStart = 2014, YearEnd = 2017, BrandId = toyota.Id, ImageUrl = "https://s3.wheelsage.org/picture/t/toyota/yaris_hybrid/toyota_yaris_hybrid_20.jpeg" },

                    //Mazda
                       new VehicleModel { Name = "3 Hatchback", YearStart = 2009, YearEnd = 2011, BrandId = mazda.Id, ImageUrl = "https://s3.wheelsage.org/picture/m/mazda/3_hatchback_i-stop/mazda3_hatchback_i-stop_7.jpeg" },
                       new VehicleModel { Name = "6", YearStart = 2012, YearEnd = 2015, BrandId = mazda.Id, ImageUrl = "https://s3.wheelsage.org/picture/m/mazda/6_sedan/mazda6_sedan_287.jpg" },
                       new VehicleModel { Name = "MX-5 Miata", YearStart = 2005, YearEnd = 2008, BrandId = mazda.Id, ImageUrl = "https://s3.wheelsage.org/picture/m/mazda/mx-5_miata/mazda_mx-5_miata_10.jpeg" }
                };

                context.VehicleModels.AddRange(models);
                context.SaveChanges();

                //3 - Create Parts
                var parts = new List<Part>
                {
                    //Civic Parts
                    new Part { Name = "Front Bumper", Description = "Primed front bumper cover", Price = 150.00m, Category = PartCategory.Body, VehicleModelId = models[0].Id },
                    new Part { Name = "Alternator", Description = "12V 100Amp Alternator", Price = 120.50m, Category = PartCategory.Mechanical, VehicleModelId = models[0].Id },
                    new Part { Name = "Radiator", Description = "Aluminum Core Radiator", Price = 85.99m, Category = PartCategory.Cooling, VehicleModelId = models[0].Id },
            
                    //Corolla Hatchback Parts
                    new Part { Name = "Headlight Assembly", Description = "Xenon Headlight Right Side", Price = 200.00m, Category = PartCategory.Body, VehicleModelId = models[3].Id },
                    new Part { Name = "Brake Pads", Description = "Front Brake Pads", Price = 45.00m, Category = PartCategory.Mechanical, VehicleModelId = models[3].Id },
                    new Part { Name = "Water Pump", Description = "Engine Water Pump with Gasket", Price = 60.00m, Category = PartCategory.Cooling, VehicleModelId = models[3].Id },

                    //Mazda 3 Parts (Using index 6 for Mazda 3 Hatchback)
                    new Part { Name = "Fender", Description = "Galvanized Front Left Fender", Price = 160.00m, Category = PartCategory.Body, VehicleModelId = models[6].Id },
                    new Part { Name = "Mirror", Description = "Exterior Right Heated Mirror", Price = 125.00m, Category = PartCategory.Body, VehicleModelId = models[6].Id},
                    new Part { Name = "Clutch", Description = "Clutch for 6-Speed Manual Transmission", Price = 199.00m, Category = PartCategory.Mechanical, VehicleModelId = models[6].Id}
                };

                context.Parts.AddRange(parts);
                context.SaveChanges();
            }
        }
    }
}
