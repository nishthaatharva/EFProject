using Application.Models.Authentication;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class AuthenticateCommand : TokenRequest, IRequest<CommandResponse>
    {

    }
}
