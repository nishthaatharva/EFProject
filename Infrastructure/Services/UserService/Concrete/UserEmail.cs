using EFProject.Data;
using EFProject.Models;
using EFProject.Services.UserService.Abstract;

namespace EFProject.Services.UserService.Concrete
{
    //interface segregation
    public class UserEmail : IUserEmail
    {
        private readonly DataContext _context;
        public UserEmail(DataContext context)
        {
            _context = context;
        }

        public Task<List<User>> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>?> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>?> UpdateUser(int id, User request)
        {
            throw new NotImplementedException();
        }
    }
}
