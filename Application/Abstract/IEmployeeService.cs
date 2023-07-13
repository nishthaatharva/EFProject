namespace EFProject.Services.EmployeeService.Abstract
{

    //Liskov Substitution Principle
    public interface IEmployeeService
    {
        public string GetDepartment(string department);
    }
}
