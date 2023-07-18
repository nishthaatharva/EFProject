using EFProject.Models;

namespace EFProject.Services.RegisterService
{
    //Open-Close Connection
    public class UserRegister : RegisterBase
    {
        public UserRegister(User user) : base(user) { 

        }
    }
}
