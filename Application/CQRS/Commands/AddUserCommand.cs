using EFProject.Models;
using MediatR;

namespace Application.CQRS.Commands
{
    public class AddUserCommand : IRequest<List<User>>
    {      
        public User User { get; set; }        
    }
}
