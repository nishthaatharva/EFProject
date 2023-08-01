using Application.Abstract;
using MediatR;

namespace Application.CQRS.Commands
{
    public class DeleteRoleHandler : IRequestHandler<DeleteRoleCommand, bool>
    {
        private readonly IRoleService _roleService;
        public DeleteRoleHandler(IRoleService roleService)
        {
            _roleService = roleService;
        }

        public async Task<bool> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            return await _roleService.DeleteRoleAsync(request.RoleName);
        }
    }
}
