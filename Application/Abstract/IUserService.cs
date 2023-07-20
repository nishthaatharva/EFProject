using Domain.Models;
using EFProject.Models;

namespace EFProject.Services.UserService.Abstract
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task<User> GetUserByRole(int role);
        Task<List<User>> GetAllUsers();
        Task<User?> GetUserById(int id);
        Task<List<User>> AddUser(User user);
        Task<List<User>?> UpdateUser(int id, User request);
        Task<List<User>?> DeleteUser(int id);   
    }

    //interface segregation Principle

    public interface IUserEmail : IUserService
    {
        Task<User?> GetEmail(string email);
    }
}
