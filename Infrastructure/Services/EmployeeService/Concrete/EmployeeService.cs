using EFProject.Services.EmployeeService.Abstract;

namespace EFProject.Services.EmployeeService.Concrete
{
    public class EmployeeService
    {
       
    }

    //Liskov Substitution Principle
    public class Employee1 : IEmployeeService
    {
        public string GetDepartment(string department)
        {
            return department;
        }
    }
    
    public class Employee2 : IEmployeeService
    {
        public string GetDepartment(string department)
        {
            return department;
        }
    }

    public class Employee3 : IEmployeeService
    {
        public string GetDepartment(string department)
        {
            return department;
        }
    }

}
