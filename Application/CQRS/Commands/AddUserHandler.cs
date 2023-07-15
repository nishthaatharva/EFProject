using EFProject.Models;
using EFProject.Services.UserService.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class AddUserHandler : IRequestHandler<AddUserCommand, List<User>>
    {
        private readonly IUserService _userService;

        public AddUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<List<User>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.AddUser(request.User);
        }

    }
}
