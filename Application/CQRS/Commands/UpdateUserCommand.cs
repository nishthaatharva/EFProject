using EFProject.Models;
using MediatR;

namespace Application.CQRS.Commands
{
    public class UpdateUserCommand : IRequest<List<User>>
    {
        public int UserId { get; set; }
        public User? Request { get; set; }
    }

}
