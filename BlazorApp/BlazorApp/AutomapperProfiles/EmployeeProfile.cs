using AutoMapper;
using BlazorApp.Data;
using BlazorApp.DTO_s;

namespace BlazorApp.AutomapperProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
        }
    }
}
