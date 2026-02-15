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
                    new Part { Name = "Front Bumper", Description = "Primed front bumper cover", Price = 150.00m, Category = PartCategory.Body, VehicleModelId = models[0].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=7282002&m=0&n=0&lng=de&rev=94077991" },
                    new Part { Name = "Alternator", Description = "12V 100Amp Alternator", Price = 120.50m, Category = PartCategory.Mechanical, VehicleModelId = models[0].Id, ImageUrl = "https://www.tarostrade.at/img/categories/file_682653_1582621197.jpg"},
                    new Part { Name = "Radiator", Description = "Aluminum core radiator", Price = 85.99m, Category = PartCategory.Cooling, VehicleModelId = models[0].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=7022938&m=0&n=0&lng=de&rev=94077991"},

                    //Accord Parts
                    new Part {Name = "Wheel Bearing Set", Description = "Left rear axle bearing set", Price = 46.00m, Category = PartCategory.Mechanical, VehicleModelId = models[1].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=13563741&m=0&n=1&lng=de&rev=94077991"},
                    new Part {Name = "Hood Lock", Description = "Hood lock", Price = 11.49m, Category = PartCategory.Body, VehicleModelId = models[1].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=16916186&m=0&n=0&lng=de&rev=94077991"},
                    new Part {Name = "Suspension Arm", Description = "Front axle right suspension arm", Price = 41.00m, Category = PartCategory.Mechanical, VehicleModelId = models[1].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=8197767&m=0&n=2&lng=de&rev=94077991"},

                    //CR-V Parts
                    new Part {Name = "Front Fender", Description = "Front right fender with moulding holes", Price = 38.49m, Category = PartCategory.Body, VehicleModelId = models[2].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=7476548&m=0&n=0&lng=de&rev=94077991"},
                    new Part {Name = "Trunk Spring", Description = "Gas spring set for the trunk", Price = 29.99m, Category = PartCategory.Body, VehicleModelId = models[2].Id, ImageUrl = "https://cdn.autodoc.de/thumb?dynamic=generic_icons&name=219&mode=5"},
                    new Part {Name = "Door Moulding Clip", Description = "Door moulding clips set", Price = 4.30m, Category = PartCategory.Interior, VehicleModelId = models[2].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=23694743&m=0&n=0&lng=de&rev=94077991"},
            
                    //Corolla Hatchback Parts
                    new Part { Name = "Headlight Assembly", Description = "Xenon Headlight right side", Price = 200.00m, Category = PartCategory.Body, VehicleModelId = models[3].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=14123680&m=0&n=1&lng=en&rev=94077991"},
                    new Part { Name = "Brake Pads", Description = "Front brake pads", Price = 45.00m, Category = PartCategory.Mechanical, VehicleModelId = models[3].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=8043074&m=0&n=1&lng=de&rev=94077991" },
                    new Part { Name = "Water Pump", Description = "Engine water pump with gasket", Price = 60.00m, Category = PartCategory.Cooling, VehicleModelId = models[3].Id, ImageUrl = "https://media.autodoc.de/360_photos/8095284/h-preview.jpg" },

                    //Hilux Parts
                    new Part {Name = "Radiator", Description = "Aluminum core radiator", Price = 200.00m, Category = PartCategory.Cooling, VehicleModelId = models[4].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=1990934&m=0&n=0&lng=de&rev=94077991"},
                    new Part {Name = "Coolant Liquid Canister", Description = "Coolant liquid canister", Price = 25.00m, Category = PartCategory.Cooling, VehicleModelId = models[4].Id, ImageUrl = "https://media.autodoc.de/360_photos/16379030/h-preview.jpg"},
                    new Part {Name = "Clutch Set", Description = "Clutch set", Price = 215.00m, Category = PartCategory.Mechanical, VehicleModelId = models[4].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=16158524&m=0&n=1&lng=de&rev=94077991"},

                    //Mazda 3 Parts
                    new Part { Name = "Fender", Description = "Front left fender", Price = 160.00m, Category = PartCategory.Body, VehicleModelId = models[6].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=7047127&m=0&n=0&lng=de&rev=94077991"},
                    new Part { Name = "Mirror", Description = "Exterior left heated mirror", Price = 125.00m, Category = PartCategory.Body, VehicleModelId = models[6].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=9305656&m=0&n=0&lng=de&rev=94077991"},
                    new Part { Name = "Clutch", Description = "Clutch for 6-Speed Manual Transmission", Price = 199.00m, Category = PartCategory.Mechanical, VehicleModelId = models[6].Id, ImageUrl = "https://media.autodoc.de/360_photos/1219795/h-preview.jpg"},

                    //Mazda 6 Parts
                    new Part { Name = "Rear Bumper", Description = "Primed rear bumper", Price = 350.00m, Category = PartCategory.Body, VehicleModelId = models[7].Id, ImageUrl ="https://cdn.autodoc.de/thumb?id=9914108&m=0&n=1&lng=de&rev=94077991" },
                    new Part { Name = "Steering Rack", Description = "Mechanical steering rach for LHD models", Price = 232.00m, Category = PartCategory.Mechanical, VehicleModelId = models[7].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=16668268&m=0&n=0&lng=de&rev=94077991"},
                    new Part { Name = "Rear Light", Description = "LED left rear light - outer part", Price = 320.50m, Category = PartCategory.Body, VehicleModelId = models[7].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=19205335&m=0&n=0&lng=de&rev=94077991"},

                    //Miata MX-5 Parts
                    new Part { Name = "Front Fender", Description = "Front right fender with bilnker hole", Price = 165.00m, Category = PartCategory.Body, VehicleModelId = models[8].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=10079260&m=0&n=0&lng=en&rev=94077991"},
                    new Part { Name = "Front Bumper", Description = "Primed front bumper", Price = 380.00m, Category = PartCategory.Body, VehicleModelId = models[8].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=15368490&m=0&n=0&lng=de&rev=94077991"},
                    new Part { Name = "Hood", Description = "Aluminum hood", Price = 450.00m, Category = PartCategory.Body, VehicleModelId = models[8].Id, ImageUrl = "https://cdn.autodoc.de/thumb?dynamic=generic_icons&name=531&mode=5"}



                };

                context.Parts.AddRange(parts);
                context.SaveChanges();
            }
        }
    }
}
