using EFProject.Services.UserService.Abstract;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.CQRS.Commands
{
    public class GenerateJwtTokenCommandHandler : IRequestHandler<GenerateJwtTokenCommand, string>
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
    public GenerateJwtTokenCommandHandler(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;           
    }               
    public async Task<string> Handle(GenerateJwtTokenCommand request, CancellationToken cancellationToken)
    {
            //var user1 = await _userService.GetUserByRole(request.Role);
            //if (user1 == null)
            //{
            //    // User not found or invalid credentials
            //    return null;
            //}

            var user = await _userService.GetUserByEmailAndPassword(request.Email, request.Password);
            if (user == null)
            {
                // User not found or invalid credentials
                return null;
            }
            
            // Generate JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.UserRoleId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(_configuration["Jwt:ExpirationHours"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var generatedToken = tokenHandler.WriteToken(token);
            return generatedToken;
            }       
    }
   
}
