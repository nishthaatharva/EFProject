using Application.Abstract;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Infrastructure.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<bool> RoleExistsAsync(string roleName)
        {
            return await _roleManager.RoleExistsAsync(roleName);
        }
        public async Task<bool> CreateRoleWithClaimsAsync(string roleName, IEnumerable<ClaimModel> claims)
        {
            if (await RoleExistsAsync(roleName))
            {
                return false;
            }
            var role = new IdentityRole(roleName);
            var createResult = await _roleManager.CreateAsync(role);
            if (!createResult.Succeeded)
            {
                return false;
            }
            foreach (var claim in claims)
            {
                var newClaim = new Claim(claim.Type, claim.Value);
                var addClaimResult = await _roleManager.AddClaimAsync(role, newClaim);
                if (!addClaimResult.Succeeded)
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<RoleModel> GetRoleWithClaimsAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return null;
            }
            var claims = await _roleManager.GetClaimsAsync(role);
            var claimModels = claims.Select(c => new ClaimModel { Type = c.Type, Value = c.Value }).ToList();
            return new RoleModel { RoleName = role.Name, Claims = claimModels };
        }
        public async Task<bool> UpdateRoleClaimsAsync(string roleName, IEnumerable<ClaimModel> claims)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return false;
            }
            var existingClaims = await _roleManager.GetClaimsAsync(role);
            foreach (var claim in existingClaims)
            {
                await _roleManager.RemoveClaimAsync(role, claim);
            }
            foreach (var claim in claims)
            {
                var newClaim = new Claim(claim.Type, claim.Value);
                await _roleManager.AddClaimAsync(role, newClaim);
            }
            return true;
        }
        public async Task<bool> DeleteRoleAsync(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return false;
            }
            var result = await _roleManager.DeleteAsync(role);
            return result.Succeeded;
        }
    }
}
