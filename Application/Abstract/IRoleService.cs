using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Application.Abstract
{
    public interface IRoleService
    {
        Task<bool> RoleExistsAsync(string roleName);
        Task<bool> CreateRoleWithClaimsAsync(string roleName, IEnumerable<ClaimModel> claims);
        Task<RoleModel> GetRoleWithClaimsAsync(string roleName);
        Task<bool> UpdateRoleClaimsAsync(string roleName, IEnumerable<ClaimModel> claims);
        Task<bool> DeleteRoleAsync(string roleName);
    }
}
