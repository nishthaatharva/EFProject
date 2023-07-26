using Application.Constants;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity.Seed
{
    public class ApplicationDbContextDataSeed
    {
        public async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Adding roles supported from constants
            await roleManager.CreateAsync(new IdentityRole(ApplicationIdentityConstants.Roles.Administrator));
            await roleManager.CreateAsync(new IdentityRole(ApplicationIdentityConstants.Roles.Member));

            //new admin user
            string adminUserName = "nishtha@test.com";
            var adminUser = new ApplicationUser
            {
                UserName = adminUserName,
                Email = adminUserName,
                IsEnabled = true,
                EmailConfirmed = true,
                FirstName = "Nishtha",
                LastName = "Administrator"
            };

            // Add new user and their role
            await userManager.CreateAsync(adminUser, ApplicationIdentityConstants.DefaultPassword);
            adminUser = await userManager.FindByNameAsync(adminUserName);
            await userManager.AddToRoleAsync(adminUser, ApplicationIdentityConstants.Roles.Administrator);            
        }
    }
}
