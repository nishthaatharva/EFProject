using Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class AddUser1Command : IRequest<ApplicationUser>
    {
        public ApplicationUser User { get; set; }
    }
}
