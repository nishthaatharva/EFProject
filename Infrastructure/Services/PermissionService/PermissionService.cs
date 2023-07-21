using Domain.Models;
using EFProject.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.PermissionService
{
    public class PermissionService : IPermissionService
    {
        private readonly DataContext _context;

        public PermissionService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<Permissions>> GetAllPermissions()
        {
            return await _context.Permissions.ToListAsync();
        }
        public async Task<Permissions> GetPermissionById(int id)
        {
            return await _context.Permissions.FindAsync(id);
        }
       
        public async Task<Permissions> CreatePermission(Permissions permission)
        {
            _context.Permissions.Add(permission);
            await _context.SaveChangesAsync();
            return permission;
        }
        public async Task<Permissions> UpdatePermission(Permissions permission)
        {
            _context.Permissions.Update(permission);
            await _context.SaveChangesAsync();
            return permission;
        }
        public async Task DeletePermission(int id)
        {
            var permission = await _context.Permissions.FindAsync(id);
            if (permission != null)
            {
                _context.Permissions.Remove(permission);
                await _context.SaveChangesAsync();
            }
        }
    }   
}
