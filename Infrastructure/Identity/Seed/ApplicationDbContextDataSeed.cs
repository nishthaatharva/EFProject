using Application.Constants;
using Application.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Identity.Seed
{
    public class ApplicationDbContextDataSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Adding roles supported from constants
            if (!await roleManager.RoleExistsAsync(ApplicationIdentityConstants.Roles.Administrator))
            {
                var adminRole = new IdentityRole(ApplicationIdentityConstants.Roles.Administrator);
                await roleManager.CreateAsync(adminRole);
            }

            //List<Claim> adminClaims = new List<Claim>();
            //adminClaims.Add(new System.Security.Claims.Claim("Permissions", "Add"));
            //adminClaims.Add(new System.Security.Claims.Claim("Permissions", "Update"));

            //foreach (var item in adminClaims)
            //{
            //    await roleManager.AddClaimAsync(adminRole, item);
            //}

            if (!await roleManager.RoleExistsAsync(ApplicationIdentityConstants.Roles.Member))
            {
                await roleManager.CreateAsync(new IdentityRole(ApplicationIdentityConstants.Roles.Member));
            }

            //new admin user
            string adminUserName = "nishtha@test.com";
            var adminUser = await userManager.FindByNameAsync(adminUserName);

            // Check if admin user already exists, if not, create and seed claims
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
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
                // adminUser = await userManager.FindByNameAsync(adminUserName);
                await userManager.AddToRoleAsync(adminUser, ApplicationIdentityConstants.Roles.Administrator);

                // Add all claims to the admin user
                var allClaims = new List<Claim>
                {
                    new Claim("Permissions", "Permissions:AddUser"),
                    new Claim("Permissions", "Permissions:UpdateUser"),
                    new Claim("Permissions", "Permissions:DeleteUser"),
                    // Add more claims as needed
                };

                foreach (var claim in allClaims)
                {
                    await userManager.AddClaimAsync(adminUser, claim);
                }
            }
        }
    }
}
