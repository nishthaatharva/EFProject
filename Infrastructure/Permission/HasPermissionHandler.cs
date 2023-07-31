using Microsoft.AspNetCore.Authorization;

namespace Infrastructure.Permission
{
    public class HasPermissionHandler : AuthorizationHandler<HasPermissionRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasPermissionRequirement requirement)
        {
            if (context.User.IsInRole("Administrator")) //Admin
            {
                // Admin role has all permissions
                context.Succeed(requirement);
            }
            else
            {
                // Check if the user has the required permission
                if (context.User.Claims.Any(c => c.Type == "Permissions" && c.Value == requirement.PermissionName))
                {
                    context.Succeed(requirement);
                }
                else
                {
                    return Task.FromException<InvalidOperationException>(new InvalidOperationException(requirement.PermissionName));
                }
            }            
            return Task.CompletedTask;               
        }          
    }   
}
