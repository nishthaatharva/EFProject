using Application.Abstract;
using Domain.Entities;
using EFProject.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class AddUserCommand : IRequest<int>
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Int64 ContactNo { get; set; }
        public string? City { get; set; }
        public string? Gender { get; set; }
        public class AddUserCommandHandler : IRequestHandler<AddUserCommand, int>
        {
            private readonly IUserDbContext context;
            public AddUserCommandHandler(IUserDbContext context)
            {
                this.context = context;  
            }

            public async Task<int> Handle(AddUserCommand command, CancellationToken cancellationToken)
            {
                var user = new User
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    Email = command.Email,
                    Password = command.Password,
                    ContactNo = command.ContactNo,
                    City = command.City,
                    Gender = command.Gender
                };
                context.Users.Add(user);
                await context.SaveChangesAsync();
                return user.Id;

            }          

        }
    }
}
