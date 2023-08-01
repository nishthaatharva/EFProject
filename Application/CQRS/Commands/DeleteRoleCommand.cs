using MediatR;

namespace Application.CQRS.Commands
{
    public class DeleteRoleCommand : IRequest<bool>
    {
        public string RoleName { get; set; }
    }
}
