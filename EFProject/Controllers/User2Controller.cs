using Application.CQRS.Commands;
using Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EFProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User2Controller : ControllerBase
    {
        //private readonly IUserService1 _userService;
        private readonly IMediator mediator;

        public User2Controller(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> AddUser(ApplicationUser user)
        {
           var command = new AddUser1Command { User = user };
            var users = await mediator.Send(command);
            return Ok(users);
        }

       
    }
}
