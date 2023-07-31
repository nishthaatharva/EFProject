using Application.Models;
using EFProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstract
{
    public interface IUserService1
    {

        //Task<List<ApplicationUser>> GetAllUsers();
        //Task<ApplicationUser?> GetUserById(int id);
        //Task<List<ApplicationUser>> AddUser(ApplicationUser user);
        //Task<List<ApplicationUser>?> UpdateUser(int id, ApplicationUser request);
        //Task<List<ApplicationUser>?> DeleteUser(int id);
        Task<ApplicationUser> AddUser(ApplicationUser user);
    }
}
