using Microsoft.AspNetCore.Identity;
using OnlineStore.Models;

namespace OnlineStore.Data
{
    public static class InitialSetup
    {
        public static async Task SeedRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            // Create roles if they are don't exsit
            string[] roleNames = { "Admin", "User" };
            foreach (var roleName in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }


        public static async Task SeedAdminUserAsync(UserManager<ApplicationUser> userManager)
        {
            // Create default admin user
            var adminEmail = "admin@example.com";
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                var user = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    firstName = "Admin",
                    lastName = "User",
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, "Admin@123456");


                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }

        }
    }
}
