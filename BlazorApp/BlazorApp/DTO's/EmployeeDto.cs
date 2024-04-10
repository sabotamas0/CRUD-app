using BlazorApp.Enums;

namespace BlazorApp.DTO_s
{
    public class EmployeeDto
    {
        public Guid Id { get; set; }
        public DateTime? HireDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }

        public double Salary { get; set; }
        public DEPARTMENT Department { get; set; }
        public CURRENCY PreferedCurrency { get; set; }
        public bool IsNetSalary { get; set; }
    }
}
