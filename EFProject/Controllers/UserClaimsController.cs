using Application.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EFProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClaimsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UserClaimsController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet("{email}")]
        public async Task<ActionResult<List<ClaimDto>>> GetUserClaims(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            var claims = await _userManager.GetClaimsAsync(user);
            var claimDtos = claims.Select(c => new ClaimDto { Type = c.Type, Value = c.Value }).ToList();
            return Ok(claimDtos);
        }

        [HttpPost("{email}")]
        public async Task<IActionResult> AddUserClaim(string email, ClaimDto claimDto)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            var claim = new Claim(claimDto.Type, claimDto.Value);
            var result = await _userManager.AddClaimAsync(user, claim);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> RemoveUserClaim(string email, ClaimDto claimDto)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            var claim = new Claim(claimDto.Type, claimDto.Value);
            var result = await _userManager.RemoveClaimAsync(user, claim);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest(result.Errors);
        }
    }
    public class ClaimDto
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
