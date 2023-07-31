using Application.Models.Authentication;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface ITokenService
    {
        Task<TokenResponse> Authentication(TokenRequest request, string ipAddress);
        Task<bool> IsValidUser(string username, string password);
        Task<ApplicationUser> GetUserByEmail(string email);
    }
}
