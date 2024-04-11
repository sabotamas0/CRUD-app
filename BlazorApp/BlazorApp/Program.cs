using BlazorApp.Data;
using BlazorApp.DTO_s;
using BlazorApp.InterfaceImplementations;
using BlazorApp.Interfaces;
using BlazorApp.Validators;
using BlazorApp.AutomapperProfiles;

namespace BlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddScoped<IEmployeeRepository, JsonRepository>();
            builder.Services.AddTransient<IEmployeeService, EmployeeService>();
            builder.Services.AddTransient<IEmployeeDtoValidator<EmployeeDto>, EmployeeDtoValidator>();
            builder.Services.AddAutoMapper(typeof(EmployeeProfile));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }


            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }
    }
}