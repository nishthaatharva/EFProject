﻿using Application.CQRS.Commands;
using Application.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EFProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class User1Controller : ControllerBase
    {
        private readonly IMediator mediator;
        public User1Controller(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var query = new GetAllUserQuery();
            var users = await mediator.Send(query);
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var query = new GetUserByIdQuery { UserId = id };
            var user = await mediator.Send(query);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            var command = new AddUserCommand { User = user };
            var validator = new AddUserCommandValidator();
            var validationResult = await validator.ValidateAsync(command);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            var users = await mediator.Send(command);
            return Ok(users);
        }
        
    [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id, User user)
        {
            var command = new UpdateUserCommand { UserId = id, Request = user };
            var users = await mediator.Send(command);
            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            var command = new DeleteUserCommand { UserId = id };
            var users = await mediator.Send(command);
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }


    }
}
