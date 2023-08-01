using Application.CQRS.Commands;
using Application.CQRS.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EFProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRoleWithClaims(string roleName, [FromBody] ClaimModel[] claims)
        {
            var command = new CreateRoleCommand { RoleName = roleName, Claims = claims };
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok($"Role '{roleName}' created with claims.");
            }
            return BadRequest($"Role '{roleName}' already exists or failed to create.");
        }
        [HttpGet("{roleName}")]
        public async Task<IActionResult> GetRoleWithClaims(string roleName)
        {
            var query = new GetRoleQuery { RoleName = roleName };
            var role = await _mediator.Send(query);
            if (role == null)
            {
                return NotFound($"Role '{roleName}' not found.");
            }
            return Ok(role);
        }
        [HttpPut("{roleName}")]
        public async Task<IActionResult> UpdateRoleClaims(string roleName, [FromBody] ClaimModel[] claims)
        {
            var command = new UpdateRoleCommand { RoleName = roleName, Claims = claims };
            var result = await _mediator.Send(command);
            if (result)
            {
                return Ok($"Claims for role '{roleName}' updated.");
            }
            return BadRequest($"Role '{roleName}' not found or failed to update claims.");
        }
        [HttpDelete("{roleName}")]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var command = new DeleteRoleCommand { RoleName = roleName };
            var role = await _mediator.Send(command);
            if (role == null)
            {
                return NotFound($"Role '{roleName}' not found.");
            }
            return Ok(role);
        }
    }
}
