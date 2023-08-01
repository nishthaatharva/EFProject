using Application.Abstract;
using MediatR;

namespace Application.CQRS.Commands
{
    public class UpdateRoleHandler : IRequestHandler<UpdateRoleCommand, bool>
    {
        private readonly IRoleService _roleService;
        public UpdateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<bool> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.UpdateRoleClaimsAsync(request.RoleName, request.Claims);
        }
    }
}
