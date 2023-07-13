using Application.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IUserDbContext context;
        public DeleteUserCommandHandler(IUserDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var user = await context.Users.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
            if (user == null)
            {
                return default;
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return user.Id;
        }
    }
}
