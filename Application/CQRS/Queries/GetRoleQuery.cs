using Domain.Models;
using MediatR;

namespace Application.CQRS.Queries
{
    public class GetRoleQuery : IRequest<RoleModel>
    {
        public string RoleName { get; set; }
    }
}
