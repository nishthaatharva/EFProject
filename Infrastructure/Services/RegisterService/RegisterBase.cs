using EFProject.Models;

namespace EFProject.Services.RegisterService
{
    //Open-Close Principle
    public abstract class RegisterBase
    {
        public User User { get; set; }
      
        public RegisterBase(User user) {
        User = user;
        }

    }

        
}
