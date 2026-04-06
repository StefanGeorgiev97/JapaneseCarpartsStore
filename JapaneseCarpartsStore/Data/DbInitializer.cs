using JapaneseCarpartsStore.Models;

namespace JapaneseCarpartsStore.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(JapaneseCarpartsStore.Data.ApplicationDbContext context)
        {

                // Ensure database is created
                context.Database.EnsureCreated();

                // Check if data exists
                if (context.Brands.Any())
                {
                    return;
                }

                //1 - Create Brands
                var honda = new Brand { Name = "Honda", ImageUrl = "https://s3.wheelsage.org/format/brand/logo/honda.png" };
                var toyota = new Brand { Name = "Toyota", ImageUrl = "https://s3.wheelsage.org/format/brand/logo/toyota.png" };
                var mazda = new Brand { Name = "Mazda", ImageUrl = "https://s3.wheelsage.org/format/brand/logo/mazda.png" };
                var mitsubishi = new Brand { Name = "Mitsubishi", ImageUrl = "https://s3.wheelsage.org/format/brand/logo/mitsubishi.png" };
                var subaru = new Brand { Name = "Subaru", ImageUrl = "https://s3.wheelsage.org/format/brand/logo/subaru.png" };
                var nissan = new Brand { Name = "Nissan", ImageUrl = "https://s3.wheelsage.org/format/brand/logo/nissan.png" };

                context.Brands.AddRange(honda, toyota, mazda, mitsubishi,subaru, nissan);
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
                       new VehicleModel { Name = "MX-5 Miata", YearStart = 2005, YearEnd = 2008, BrandId = mazda.Id, ImageUrl = "https://s3.wheelsage.org/picture/m/mazda/mx-5_miata/mazda_mx-5_miata_10.jpeg" },
                    
                    // Mitsubishi
                       new VehicleModel { Name = "Lancer", YearStart = 2008, YearEnd = 2015, BrandId = mitsubishi.Id, ImageUrl = "https://s3.wheelsage.org/format/picture/picture-gallery-full/m/mitsubishi/lancer_gt/mitsubishi_lancer_gt_23.avif" },
                       new VehicleModel { Name = "Outlander", YearStart = 2013, YearEnd = 2020, BrandId = mitsubishi.Id, ImageUrl = "https://s3.wheelsage.org/picture/m/mitsubishi/outlander/mitsubishi_outlander_194.jpg" },
                       new VehicleModel { Name = "Pajero", YearStart = 2014, YearEnd = 2019, BrandId = mitsubishi.Id, ImageUrl = "https://s3.wheelsage.org/picture/m/mitsubishi/pajero_3-door/mitsubishi_pajero_3-door.png" },

                    // Subaru
                       new VehicleModel { Name = "Impreza", YearStart = 2012, YearEnd = 2016, BrandId = subaru.Id, ImageUrl = "https://s3.wheelsage.org/picture/s/subaru/impreza_g4_1.6i/subaru_impreza_g4_1.6i_6.jpeg" },
                       new VehicleModel { Name = "Forester", YearStart = 2008, YearEnd = 2011, BrandId = subaru.Id, ImageUrl = "https://s3.wheelsage.org/picture/s/subaru/forester_2.0d/subaru_forester_2.0d_56.jpeg" },
                       new VehicleModel { Name = "Outback", YearStart = 2017, YearEnd = 2019, BrandId = subaru.Id, ImageUrl = "https://s3.wheelsage.org/picture/s/subaru/outback_3.6r/subaru_outback_3.6r_20.jpeg" },

                    // Nissan
                       new VehicleModel { Name = "Qashqai", YearStart = 2014, YearEnd = 2021, BrandId = nissan.Id, ImageUrl = "https://s3.wheelsage.org/picture/n/nissan/qashqai/nissan_qashqai_6.jpg" },
                       new VehicleModel { Name = "X-Trail", YearStart = 2014, YearEnd = 2020, BrandId = nissan.Id, ImageUrl = "https://s3.wheelsage.org/picture/n/nissan/x-trail_black_edition/nissan_x-trail_black_edition_1.jpeg" },
                       new VehicleModel { Name = "Juke", YearStart = 2010, YearEnd = 2014, BrandId = nissan.Id, ImageUrl = "https://s3.wheelsage.org/picture/n/nissan/juke_premium_white_package/nissan_juke_premium_white_package_7.jpg" }

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
                    new Part { Name = "Hood", Description = "Aluminum hood", Price = 450.00m, Category = PartCategory.Body, VehicleModelId = models[8].Id, ImageUrl = "https://cdn.autodoc.de/thumb?dynamic=generic_icons&name=531&mode=5"},

                    // Mitsubishi Lancer
                    new Part { Name = "Front Bumper", Description = "Front bumper primed", Price = 180.00m, Category = PartCategory.Body, VehicleModelId = models[9].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=7608801&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Clutch Kit", Description = "Automatic gearbox clutch kit", Price = 220.00m, Category = PartCategory.Mechanical, VehicleModelId = models[9].Id, ImageUrl = "https://media.autodoc.de/360_photos/1219795/h-preview.jpg" },
                    new Part { Name = "Radiator", Description = "", Price = 95.00m, Category = PartCategory.Cooling, VehicleModelId = models[9].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=7022938&m=0&n=0&lng=de&rev=94077991" },

                    // Mitsubishi Outlander
                    new Part { Name = "Brake Discs", Description = "Front brake discs - ATE", Price = 140.00m, Category = PartCategory.Mechanical, VehicleModelId = models[10].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=7428148&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Rear Bumper", Description = "Rear bumper - PRASCO - without primer - no parking sensor holes", Price = 260.00m, Category = PartCategory.Body, VehicleModelId = models[10].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=15302118&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Water Pump", Description = "Water pump for 2.0 (GF2W) engine", Price = 75.00m, Category = PartCategory.Cooling, VehicleModelId = models[10].Id, ImageUrl = "https://media.autodoc.de/360_photos/8095284/h-preview.jpg" },

                    // Mitsubishi Pajero
                    new Part { Name = "Suspension Shock-absorber", Description = "Gas shock absorber for the Rear Axle", Price = 110.00m, Category = PartCategory.Mechanical, VehicleModelId = models[11].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=8002794&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Front Grille", Description = "Front grille with chrome stripes and emblem holder", Price = 130.00m, Category = PartCategory.Body, VehicleModelId = models[11].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=7151282&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Coolant Tank", Description = "Coolant liquid reservoir", Price = 45.00m, Category = PartCategory.Cooling, VehicleModelId = models[11].Id, ImageUrl = "https://media.autodoc.de/360_photos/16379030/h-preview.jpg" },

                    // Subaru Impreza
                    new Part { Name = "Headlight", Description = "Front left headlight with Xenon and H11 bulbs", Price = 210.00m, Category = PartCategory.Body, VehicleModelId = models[12].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=9268964&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Brake Pads", Description = "Brake pads set front/rear", Price = 55.00m, Category = PartCategory.Mechanical, VehicleModelId = models[12].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=8043074&m=0&n=1&lng=de&rev=94077991" },
                    new Part { Name = "Radiator", Description = "Radiator for 1.6 i (GP2) Engine", Price = 100.00m, Category = PartCategory.Cooling, VehicleModelId = models[12].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=7022938&m=0&n=0&lng=de&rev=94077991" },

                    // Subaru Forester
                    new Part { Name = "Front Fender", Description = "Front left fender with blinker hole - no primer", Price = 150.00m, Category = PartCategory.Body, VehicleModelId = models[13].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=8154148&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Alternator", Description = "12V, 110A Alternator", Price = 170.00m, Category = PartCategory.Mechanical, VehicleModelId = models[13].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=14351301&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Cooling Fan", Description = "300mm, 12V, 140W cooling fan", Price = 85.00m, Category = PartCategory.Cooling, VehicleModelId = models[13].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=21588670&m=0&n=0&lng=de&rev=94078007" },

                    // Subaru Outback
                    new Part { Name = "Rear Light", Description = "Left inner rear light with bulb holders - TYC", Price = 190.00m, Category = PartCategory.Body, VehicleModelId = models[14].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=17397153&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Steering Rack", Description = "Mechanical steering rack for LHD models", Price = 260.00m, Category = PartCategory.Mechanical, VehicleModelId = models[14].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=16668268&m=0&n=0&lng=de&rev=94077991" },
                    new Part { Name = "Thermostat", Description = "Cooling liquid thermostat for 2.0 D AWD (BSD) engines", Price = 35.00m, Category = PartCategory.Cooling, VehicleModelId = models[14].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=23011302&m=0&n=0&lng=de&rev=94078007" },

                    // Nissan Qashqai
                    new Part { Name = "Front Bumper", Description = "Front bumper - with fog light holes - no parking sensor holes - no primer", Price = 240.00m, Category = PartCategory.Body, VehicleModelId = models[15].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=9916333&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Brake Pads", Description = "Brake pads set front/rear", Price = 60.00m, Category = PartCategory.Mechanical, VehicleModelId = models[15].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=8043074&m=0&n=1&lng=de&rev=94077991" },
                    new Part { Name = "Radiator", Description = "Aluminium water cooler for 1.2 DIG-T engine", Price = 120.00m, Category = PartCategory.Cooling, VehicleModelId = models[15].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=16149873&m=0&n=0&lng=de&rev=94078007" },

                    // Nissan X-Trail
                    new Part { Name = "Rear Bumper", Description = "Rear bumper primed, with reflector openings", Price = 300.00m, Category = PartCategory.Body, VehicleModelId = models[16].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=18524441&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Suspension Arm", Description = "Front axle lower right suspension arm - steel", Price = 170.00m, Category = PartCategory.Mechanical, VehicleModelId = models[16].Id, ImageUrl = "https://media.autodoc.de/360_photos/16364238/h-preview.jpg" },
                    new Part { Name = "Water Pump", Description = "Water pump with gasket", Price = 90.00m, Category = PartCategory.Cooling, VehicleModelId = models[16].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=20473634&m=0&n=0&lng=de&rev=94078007" },

                    // Nissan Juke
                    new Part { Name = "Headlight", Description = "Left headlight with H4 bulb", Price = 210.00m, Category = PartCategory.Body, VehicleModelId = models[17].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=8349794&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Clutch Kit", Description = "Clutch kit for manual transmissions", Price = 260.00m, Category = PartCategory.Mechanical, VehicleModelId = models[17].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=8159433&m=0&n=0&lng=de&rev=94078007" },
                    new Part { Name = "Cooling Fan", Description = "220/150W cooling fan with frame and control module", Price = 95.00m, Category = PartCategory.Cooling, VehicleModelId = models[17].Id, ImageUrl = "https://cdn.autodoc.de/thumb?id=8058917&m=0&n=0&lng=de&rev=94078007" },

                };

                context.Parts.AddRange(parts);
                await context.SaveChangesAsync();
            
        }
    }
}
