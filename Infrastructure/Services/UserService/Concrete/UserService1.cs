using Application.Abstract;
using Application.Models;
using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Services.UserService.Concrete
{
    public class UserService1 : IUserService1
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
      //  private readonly RoleManager<IdentityRole> _roleManager;
        public UserService1(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
           // _roleManager = roleManager;
        }
        public async Task<ApplicationUser> AddUser(ApplicationUser user)
        {
            ApplicationUser appUser = new ApplicationUser
            {                             
                Email = user.Email,
                UserName = user.Email,
                IsEnabled = true,
                EmailConfirmed = true,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = user.PasswordHash
            };


            // Create the user using UserManager
            await _userManager.CreateAsync(appUser, appUser.PasswordHash);

            // Add the claim to the user
          //  await _userManager.AddClaimAsync(appUser, new Claim("Permissions", "Permissions:AddUser"));

            // Add the user to the "Member" role
            await _userManager.AddToRoleAsync(appUser, "Member");

            await _context.SaveChangesAsync();
            return appUser;
        }

        public Task<List<ApplicationUser>?> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ApplicationUser>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser?> GetUserById(int id)
        {
            throw new NotImplementedException();
            //return   _context.UserClaims.Where(x => x.UserId == id)
        }

        public Task<List<ApplicationUser>?> UpdateUser(int id, ApplicationUser request)
        {
            throw new NotImplementedException();
        }
    }
}
