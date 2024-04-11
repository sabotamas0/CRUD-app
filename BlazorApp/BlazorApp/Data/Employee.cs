using BlazorApp.Enums;

namespace BlazorApp.Data
{
    public class Employee
    {
        public Guid Id { get; set; }
        public DateTime? HireDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public double Salary { get; set; }
        public DEPARTMENT Department { get; set; }
        public bool IsNetSalary { get; set; }
        public CURRENCY PreferedCurrency { get; set; }
        public Employee(Guid id, DateTime? hiredate, string name, string email, string phone, double salary, DEPARTMENT department, bool isnetsalary, CURRENCY preferedcurrency)
        {
            Id = id;
            HireDate= hiredate;
            Name = name;
            Email = email;
            Phone = phone;
            Salary = salary;
            Department = department;
            IsNetSalary = isnetsalary;
            PreferedCurrency= preferedcurrency;
        }
    }
}
