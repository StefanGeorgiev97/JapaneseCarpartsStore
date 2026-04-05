using JapaneseCarpartsStore.Core.Contracts;
using JapaneseCarpartsStore.Core.Services;
using JapaneseCarpartsStore.Data;
using JapaneseCarpartsStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Localization;


namespace JapaneseCarpartsStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddControllersWithViews();
            
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IPartService, PartService>();

            // Identity Configuration
            builder.Services.AddDefaultIdentity<ApplicationUser>(options => {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
          
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<IOrderService, OrderService>();

            builder.Services.AddSession();

            var app = builder.Build();


            // Handle globalization
            var supportedCultures = new[] { new CultureInfo("en-US") }; // standardize for Dollar
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("de-DE"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            // Error handling
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error/500");
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            // Seed roles and admin user
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                IdentitySeeder.SeedAdminAsync(services).GetAwaiter().GetResult();
            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();
            app.UseAuthentication(); // To check passwords

            app.UseAuthorization();

            app.MapRazorPages();

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            //Seed Database
            JapaneseCarpartsStore.Data.DbInitializer.Seed(app);


            app.Run();
        }
    }
}
