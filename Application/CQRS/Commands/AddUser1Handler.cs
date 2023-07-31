using Application.Abstract;
using Application.Models;
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
    public class AddUser1Handler : IRequestHandler<AddUser1Command, ApplicationUser>
    {
        private readonly IUserService1 _userService1;
        public AddUser1Handler(IUserService1 userService1) {
            _userService1 = userService1;
        }

        public async Task<ApplicationUser> Handle(AddUser1Command request, CancellationToken cancellationToken)
        {
            return await _userService1.AddUser(request.User);
        }
    }
}
