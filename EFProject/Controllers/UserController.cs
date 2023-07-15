using EFProject.Models;
using EFProject.Services.UserService.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;   
        public UserController(IUserService userService)
        {
            _userService = userService;               
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            return await _userService.GetAllUsers();
        }
        //Get userId
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var result = await _userService.GetUserById(id);
            if (result is null)
                return NotFound("User not found");
            return Ok(result);
        }
        //Post method to add user in database
        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            var result = await _userService.AddUser(user);
            
            return Ok(result);
        }

        //Put method to update a user in database
        [HttpPut("{id}")]
        public async Task<ActionResult<List<User>>> UpdateUser(int id,User request)
        {
            var result = await _userService.UpdateUser(id, request);
            if (result is null)
                return NotFound("User not found");
            return Ok(result);
        }

        //delete a user in database

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
           var result = await _userService.DeleteUser(id);
            if (result is null)
                return NotFound("User not found");
            return Ok(result);
        }

    }
}
