using BlazorApp.Data;
using BlazorApp.DTO_s;

namespace BlazorApp.Interfaces
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        Employee GetEmployeeById(Guid employeeId);
        void AddEmployee(EmployeeDto employee);
        void DeleteEmployee(Guid employeeId);
        void UpdateEmployee(EmployeeDto employee);
    }
}
