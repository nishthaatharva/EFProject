using Domain.Models;
using EFProject.Models;

namespace Infrastructure.Services.PermissionService
{
    public interface IPermissionService
    {
        Task<List<Permissions>> GetAllPermissions();
        Task<Permissions?> GetPermissionById(int id);
        Task<Permissions> CreatePermission(Permissions permission);
        Task<Permissions> UpdatePermission(Permissions permission);
        Task DeletePermission(int id);
    }
}