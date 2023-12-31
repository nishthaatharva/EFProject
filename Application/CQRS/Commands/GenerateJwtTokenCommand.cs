﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Commands
{
    public class GenerateJwtTokenCommand : IRequest<string>
    {
       // public int Role { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }    

}
