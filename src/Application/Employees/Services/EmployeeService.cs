using Employee.Application.Employees.Interfaces;
using Employee.Application.Employees.Models;
using Employee.Domain.Entities;
using Employee.Domain.Interfaces;
using Employee.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Application.Employees.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly INotification _notification;

        public EmployeeService(IEmployeeRepository employeeRepository, INotification notification)
        {
            _employeeRepository = employeeRepository;
            _notification = notification;
        }

        public async Task<BaseResponse> AddAsync(EmployeeRequest employeeRequest)
        {
            var employee = new EmployeeRecord
            {
                Id = employeeRequest.Id,
                Name = employeeRequest.Name,
                Age = employeeRequest.Age,
                Address = employeeRequest.Address
            };

            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveChangesAsync();

            return new BaseResponse { Success = true, Message = "Employee added successfully." };
        }

        public async Task<BaseResponse> DeleteAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee == null)
            {
                _notification.AddError("Employee not found.");
                return new BaseResponse { Success = false, Message = "Employee not found." };
            }

            _employeeRepository.Delete(employee);
            await _employeeRepository.SaveChangesAsync();

            return new BaseResponse { Success = true, Message = "Employee deleted successfully." };
        }

        public async Task<IEnumerable<EmployeeResponse>> GetAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            var response = new List<EmployeeResponse>();
            foreach (var emp in employees)
            {
                response.Add(emp);
            }
            return response;
        }

        public async Task<EmployeeResponse> GetAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return employee;
        }

        public async Task<BaseResponse> UpdateAsync(EmployeeRequest employeeRequest)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeRequest.Id);
            if (employee == null)
            {
                _notification.AddError("Employee not found.");
                return new BaseResponse { Success = false, Message = "Employee not found." };
            }

            employee.Name = employeeRequest.Name;
            employee.Age = employeeRequest.Age;
            employee.Address = employeeRequest.Address;

            _employeeRepository.Update(employee);
            await _employeeRepository.SaveChangesAsync();

            return new BaseResponse { Success = true, Message = "Employee updated successfully." };
        }
    }
}