using Employee.Application.Employees.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Application.Employees.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeResponse>> GetAsync();
        Task<EmployeeResponse> GetAsync(int id);
        Task<BaseResponse> AddAsync(EmployeeRequest employeeRequest);
        Task<BaseResponse> UpdateAsync(EmployeeRequest employeeRequest);
        Task<BaseResponse> DeleteAsync(int id);
    }
}