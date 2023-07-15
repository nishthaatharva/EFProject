using Application.Abstract;
using EFProject.Models;
using EFProject.Services.UserService.Abstract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class AddUserCommand : IRequest<List<User>>
    {      
        public User User { get; set; }
        
    }
}
