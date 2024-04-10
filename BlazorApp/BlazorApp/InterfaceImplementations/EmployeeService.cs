using BlazorApp.Data;
using BlazorApp.DTO_s;
using BlazorApp.Interfaces;
using System.Transactions;

namespace BlazorApp.InterfaceImplementations
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        public EmployeeService(IEnumerable<IEmployeeRepository> repositories)
        {
            foreach (var repository in repositories)
            {
                if (repository is JsonRepository)
                {
                    _employeeRepository = repository;
                    break;
                }
            }
        }

        public void AddEmployee(EmployeeDto employee)
        {
            _employeeRepository.Create(employee);
        }

        public void DeleteEmployee(Guid employeeId)
        {
            _employeeRepository.Delete(employeeId);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.Read();
        }

        public void UpdateEmployee(EmployeeDto employee)
        {
            _employeeRepository.Update(employee);
        }
        public Employee GetEmployeeById(Guid employeeId)
        {
            var employees = _employeeRepository.Read();
            return employees.Where(x => x.Id == employeeId).Single();
        }
    }
}
