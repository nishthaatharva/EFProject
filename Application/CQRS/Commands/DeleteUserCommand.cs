using EFProject.Models;
using MediatR;

namespace Application.CQRS.Commands
{
    public class DeleteUserCommand : IRequest<List<User>>
    {
        public int UserId { get; set; }
    }
}
