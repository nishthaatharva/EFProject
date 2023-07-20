using Domain.Models;

namespace EFProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set;}
        public string? Email { get; set; }
        public string? Password { get; set; }
        public Int64 ContactNo { get; set; }
        public string? City { get; set; }
        public string? Gender { get; set; }
        public int UserRoleId { get; set; } //foreign key   

    }
}
