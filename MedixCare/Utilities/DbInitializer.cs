using MedixCare.Models;
using Microsoft.AspNetCore.Identity;

namespace MedixCare.Utilities
{
    public class DbInitializer
    {
        public static async Task SeedRolesAndAdmin(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = { "Admin", "Doctor", "Patient", "Staff" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            //seed main
            var admin = await userManager.FindByEmailAsync("admin@medixcare.com");
            if (admin != null)
            {
                var newAdmin = new ApplicationUser
                {

                    UserName = "admin@medixcare.com",
                    Email = "admin@medixcare.com",
                    FullName = "System Administator",
                    EmailConfirmed = true

                };

                await userManager.CreateAsync(newAdmin, "Admin@123");
                await userManager.AddToRoleAsync(newAdmin, "Admin");

            }
        }
    }

}
