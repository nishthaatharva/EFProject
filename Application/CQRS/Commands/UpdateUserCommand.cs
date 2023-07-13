using Application.Abstract;
using EFProject.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Int64 ContactNo { get; set; }
        public string? City { get; set; }
        public string? Gender { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
        {
            private readonly IUserDbContext context;
            public UpdateUserCommandHandler(IUserDbContext context)
            {
                this.context = context;
            }

            public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                var user = context.Users.Where(a => a.Id == command.Id).FirstOrDefault();
                if (user == null)
                {
                    return default;
                }

                user.FirstName = command.FirstName;
                user.LastName = command.LastName;
                user.Email = command.Email;
                user.Password = command.Password;
                user.ContactNo = command.ContactNo;
                user.City = command.City;
                user.Gender = command.Gender;

                await context.SaveChangesAsync();
                return user.Id;
            }

        }
    }
}
