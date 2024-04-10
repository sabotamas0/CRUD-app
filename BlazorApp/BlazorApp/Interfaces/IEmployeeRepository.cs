using BlazorApp.Data;
using BlazorApp.DTO_s;

namespace BlazorApp.Interfaces
{
    public interface IEmployeeRepository
    {
        List<Employee> Read();
        void Create(EmployeeDto partner);
        void Update(EmployeeDto partner);
        void Delete(Guid transactionId);
    }
}
