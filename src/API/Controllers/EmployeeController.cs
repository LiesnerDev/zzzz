using Microsoft.AspNetCore.Mvc;
using Employee.Application.Employees.Models;
using Employee.Application.Employees.Services;
using Employee.Domain.SeedWork;

namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService, INotification notification) : base(notification)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Response(await _employeeService.GetAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Response(await _employeeService.GetAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeRequest employeeRequest)
        {
            return Response(await _employeeService.AddAsync(employeeRequest));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeRequest employeeRequest)
        {
            employeeRequest.Id = id;
            return Response(await _employeeService.UpdateAsync(employeeRequest));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Response(await _employeeService.DeleteAsync(id));
        }
    }
}