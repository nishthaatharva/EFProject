using Domain.Models;
using EFProject.Data;

namespace Infrastructure.Permission
{
    public class SeedData
    {
        public static async Task Initialize(DataContext context)            
        {
            // Check if roles and permissions already exist
            if (!context.UserRoles.Any())
            {
                var roles = new List<UserRole>
            {
                new UserRole { Name = "Admin" },
                new UserRole { Name = "Manager" },
                new UserRole { Name = "User" }
            };
                await context.UserRoles.AddRangeAsync(roles);
                await context.SaveChangesAsync();
            }
            if (!context.Permissions.Any())
            {
                var permissions = new List<Permissions>
            {
                new Permissions { Name = "EditUser" },
                new Permissions { Name = "AddUser" },
                new Permissions { Name = "DeleteUser" }
            };
                await context.Permissions.AddRangeAsync(permissions);
                await context.SaveChangesAsync();
            }
        }
    }
}
