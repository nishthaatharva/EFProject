using Application.Abstract;
using MediatR;

namespace Application.CQRS.Commands
{
    public class CreateRoleHandler : IRequestHandler<CreateRoleCommand, bool>
    {
        private readonly IRoleService _roleService;
        public CreateRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }
        public async Task<bool> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.CreateRoleWithClaimsAsync(request.RoleName, request.Claims);
        }
    }
}
