using Newtonsoft.Json;
using BlazorApp.Interfaces;
using BlazorApp.DTO_s;
using BlazorApp.Data;

namespace BlazorApp.InterfaceImplementations
{
    public class JsonRepository : IEmployeeRepository
    {
        private List<Employee> _Employees;
        private List<Employee> Employees
        {
            get
            {
                if (_Employees == null)
                {
                    return _Employees = Read();
                }
                return _Employees;
            }
        }

        public void Delete(Guid employeeId)
        {
            var employeeToBeDeleted = Employees.Where(x => x.Id == employeeId).Single();

            Employees.Remove(employeeToBeDeleted);

            string json = JsonConvert.SerializeObject(Employees.ToArray());

            System.IO.File.WriteAllText("Employees.json", json);
        }

        public List<Employee> Read()
        {
            return JsonConvert.DeserializeObject<List<Employee>>(File.ReadAllText("Employees.json"));
        }

        public void Update(EmployeeDto employee)
        {
            //TODO
            string json = JsonConvert.SerializeObject(Employees.ToArray());

            System.IO.File.WriteAllText("Employees.json", json);
        }

        public void Create(EmployeeDto employee)
        {
           
            var newEmployee = new Employee(Guid.NewGuid(), employee.HireDate,employee.Name,employee.Email,employee.Phone,employee.Age,employee.Salary,employee.Department,employee.IsNetSalary,employee.PreferedCurrency);

            Employees.Add(newEmployee);

            string json = JsonConvert.SerializeObject(Employees.ToArray());

            System.IO.File.WriteAllText("Employees.json", json);
        }
    }
}
