using Employee.Application.Employees.Interfaces;
using Employee.Application.Employees.Services;
using Employee.Domain.Interfaces;
using Employee.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Employee.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Services
            services.AddScoped<IEmployeeService, EmployeeService>();

            return services;
        }
    }
}