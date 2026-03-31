using System.Threading.Tasks;
using JapaneseCarpartsStore.Models;
using Microsoft.AspNetCore.Identity;

namespace JapaneseCarpartsStore.Core.Services
{
    public static class IdentitySeeder
    {
        public static async Task SeedAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            // Create the Administrator Role if it doesn't exist
            if (!await roleManager.RoleExistsAsync("Administrator"))
            {
                await roleManager.CreateAsync(new IdentityRole("Administrator"));
            }

            // Create the default Admin User
            string adminEmail = "admin@store.com";
            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(admin, "Admin123!"); // Change this password later
                await userManager.AddToRoleAsync(admin, "Administrator");
            }
        }
    }
}