using BlazorApp.Data;
using BlazorApp.DTO_s;
using System.Text.RegularExpressions;
using FluentValidation;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Interfaces
{
    public interface IEmployeeDtoValidator<TValidator> : IValidator
    {
        public bool IsEmployeePhoneExist(string employeePhone, List<Employee> employees);
        public bool IsEmployeeEmailExist(string employeeEmail, List<Employee> employees);
        public bool IsPhoneNumber(string number);
    }
}
