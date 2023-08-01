using Application.Abstract;
using Domain.Models;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetRoleHandler : IRequestHandler<GetRoleQuery, RoleModel>
    {
      private readonly IRoleService _roleService;
      public GetRoleHandler(IRoleService roleService)
         {
              _roleService = roleService;
         }
       public async Task<RoleModel> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
             return await _roleService.GetRoleWithClaimsAsync(request.RoleName);
        }
    }
}
