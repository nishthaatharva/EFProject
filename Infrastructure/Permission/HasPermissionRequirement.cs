using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
