using AutoMapper;
using BlazorApp.Data;
using BlazorApp.DTO_s;
using BlazorApp.Interfaces;
using System.Net;
using System.Transactions;

namespace BlazorApp.InterfaceImplementations
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private IMapper _mapper;
        public EmployeeService(IEnumerable<IEmployeeRepository> repositories, IMapper mapper)
        {
            foreach (var repository in repositories)
            {
                if (repository is JsonRepository)
                {
                    _employeeRepository = repository;
                    break;
                }
            }
            _mapper = mapper;
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
        public EmployeeDto GetEmployeeById(Guid employeeId)
        {
            var employees = _employeeRepository.Read();
            return _mapper.Map<EmployeeDto>(employees.Where(x => x.Id == employeeId).Single());
        }
    }
}
