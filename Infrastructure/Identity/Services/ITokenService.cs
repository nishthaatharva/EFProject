using Infrastructure.Identity.Models;
using Infrastructure.Identity.Models.Authentication;

namespace Infrastructure.Identity.Services
{
    public interface ITokenService
    {
        Task<TokenResponse> Authentication(TokenRequest request, string ipAddress);
        Task<bool> IsValidUser(string username, string password);
        Task<ApplicationUser> GetUserByEmail(string email);      
    }
}
