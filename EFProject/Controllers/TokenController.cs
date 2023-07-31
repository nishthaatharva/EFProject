using Application.CQRS.Commands;
using Application.Models.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EFProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TokenController(IMediator mediator)
        {
            _mediator = mediator;
        }      
   
        //     Validate that the user account is valid and return an auth token
        //     to the requesting app for use in the api.
      
        [AllowAnonymous]
        [HttpPost("Authenticate")]
       // [ProducesResponseType(Microsoft.AspNetCore.Http.StatusCodes.Status200OK)]
       // [ProducesResponseType(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Post))]
        public async Task<TokenResponse> AuthenticateAsync([FromBody] AuthenticateCommand command)
        {
            var response = await _mediator.Send(command);
            return response.Resource;
        }
    }
}
