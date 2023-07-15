using Application.Abstract;
using EFProject.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class DeleteUserCommand : IRequest<List<User>>
    {
        public int UserId { get; set; }
    }
}
