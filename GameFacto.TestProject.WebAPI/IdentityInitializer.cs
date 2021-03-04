using GameFacto.TestProject.WebAPI.Context;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace GameFacto.TestProject.WebAPI
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "admin" });
            }

            var productViewRole = await roleManager.FindByNameAsync("product_view");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole { Name = "product_view" });
            }

            var adminUser = await userManager.FindByNameAsync("msekinci");
            if (adminUser == null)
            {
                AppUser admin = new AppUser 
                { 
                    Name = "Mehmet Serkan", 
                    Surname = "Ekinci", 
                    UserName = "msekinci", 
                    Email = "mehmet@ekinci.com" 
                };

                await userManager.CreateAsync(admin, "adminPassword123");
                await userManager.AddToRoleAsync(admin, "admin");

                AppUser readOnly = new AppUser
                {
                    Name = "Read",
                    Surname = "Only",
                    UserName = "readonly",
                };

                await userManager.CreateAsync(readOnly, "readOnly123");
                await userManager.AddToRoleAsync(readOnly, "product_view");

            }
        }
    }
}
