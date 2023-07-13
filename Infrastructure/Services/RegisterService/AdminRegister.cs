using EFProject.Models;

namespace EFProject.Services.RegisterService
{
    //Open-Close Principle
    public class AdminRegister : RegisterBase
    {
        public int RoleId { get; set; }

        public AdminRegister(User user, int roleId) : base(user)
        {
            RoleId = roleId;
        }
    }
}
