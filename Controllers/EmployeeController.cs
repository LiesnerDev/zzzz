using Microsoft.AspNetCore.Mvc;
using EmployeeRegistration.Models;
using EmployeeRegistration.Services;

namespace EmployeeRegistration.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            // Validações
            if (employee.Id < 1000 || employee.Id > 9999)
            {
                return BadRequest("O ID deve conter 4 dígitos num\u00E9ricos.");
            }
            if (string.IsNullOrWhiteSpace(employee.Name) || employee.Name.Length > 20)
            {
                return BadRequest("O Nome deve conter at\u00E9 20 caracteres.");
            }
            if (employee.Age < 10 || employee.Age > 99)
            {
                return BadRequest("A Idade deve conter 2 d\u00EDgitos num\u00E9ricos.");
            }
            if (string.IsNullOrWhiteSpace(employee.Address) || employee.Address.Length > 30)
            {
                return BadRequest("O Endere\u00E7o deve conter at\u00E9 30 caracteres.");
            }

            try
            {
                EmployeeService.AddEmployee(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

            return Ok("Employee record added");
        }
    }
}
