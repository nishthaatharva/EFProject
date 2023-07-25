using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Permission
{
    public class HasPermissionRequirement : IAuthorizationRequirement
    {
        public string PermissionName { get; }
        public HasPermissionRequirement(string permissionName)
        {
            PermissionName = permissionName;
        }
    }
}
