using EFProject.Data;
using EFProject.Models;
using EFProject.Services.UserService.Abstract;
using Microsoft.EntityFrameworkCore;

namespace EFProject.Services.UserService.Concrete
{
    public class UserService : IUserService
    {

        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<User>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>?> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user is null)
                return null;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<User?> GetUserById(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
                return null;
            return users;
        }

        public async Task<List<User>?> UpdateUser(int id, User request)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.Password = request.Password;
            user.ContactNo = request.ContactNo;
            user.City = request.City;
            user.Gender = request.Gender;

            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }
    }
}
