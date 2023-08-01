using Domain.Models;
using MediatR;

namespace Application.CQRS.Commands
{
    public class CreateRoleCommand : IRequest<bool>
    {
        public string RoleName { get; set; }
        public IEnumerable<ClaimModel> Claims { get; set; }
    
    }
}
