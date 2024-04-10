using BlazorApp.Data;
using BlazorApp.DTO_s;
using BlazorApp.Interfaces;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BlazorApp.Validators
{
    public class EmployeeDtoValidator : AbstractValidator<EmployeeDto>, IEmployeeDtoValidator<EmployeeDto>
    {
        private IEmployeeService _employeeService;
        public EmployeeDtoValidator(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            var employees = employeeService.GetAllEmployees();
            RuleFor(x => x.Age).NotNull()
            .WithMessage("Please Enter Value")
            .InclusiveBetween(16, 80)
            .WithMessage("Age must be number Beetween 16 , 80");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Enter Employee name");
            RuleFor(x => x.Phone).NotEmpty().NotNull().WithMessage("Enter Employee phone");
            RuleFor(m => new { m.Phone }).Must(x => !IsEmployeePhoneExist(x.Phone,employees)).WithMessage("Existing Employee Phone Number!");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("Enter Employee email").EmailAddress().WithMessage("A valid email is required");
            RuleFor(m => new { m.Email }).Must(x => !IsEmployeeEmailExist(x.Email, employees)).WithMessage("Existing Employee Email!");
            When(d => !string.IsNullOrEmpty(d.Phone), () =>
            {
                RuleFor(m => new { m.Phone }).Must(x => !IsPhoneNumber(x.Phone)).WithMessage("Invalid Phone Number!");
            });
            RuleFor(x => x.HireDate).NotNull().WithMessage("Complete Date is not a valid date.");
        }
        public bool IsEmployeePhoneExist(string employeePhone, List<Employee> employees)
        {
            return employees.Where(x => x.Phone == employeePhone).Any();
        }
        public bool IsEmployeeEmailExist(string employeeEmail, List<Employee> employees)
        {
            return employees.Where(x => x.Email == employeeEmail).Any();
        }
        public bool IsPhoneNumber(string number)
        {
            return Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        }
    }

}
