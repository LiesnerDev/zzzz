using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using MyProject.Models;
using MyProject.Services;

namespace MyProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }
        
        [HttpPost("register")]
        public IActionResult Register([FromBody] EmployeeRequest request)
        {
            // Validação do ID do Funcionário: exatamente 4 dígitos numéricos
            if (string.IsNullOrWhiteSpace(request.EmployeeId) || !Regex.IsMatch(request.EmployeeId, @"^\d{4}$"))
            {
                return BadRequest("O ID deve conter 4 dígitos numéricos.");
            }
            
            // Validação do Nome do Funcionário: até 20 caracteres
            if (string.IsNullOrWhiteSpace(request.Name) || request.Name.Length > 20)
            {
                return BadRequest("O Nome deve conter até 20 caracteres.");
            }

            // Validação da Idade do Funcionário: 2 dígitos numéricos
            if (string.IsNullOrWhiteSpace(request.Age) || !Regex.IsMatch(request.Age, @"^\d{2}$"))
            {
                return BadRequest("A Idade deve conter 2 dígitos numéricos.");
            }

            // Validação do Endereço do Funcionário: até 30 caracteres
            if (string.IsNullOrWhiteSpace(request.Address) || request.Address.Length > 30)
            {
                return BadRequest("O Endereço deve conter até 30 caracteres.");
            }
            
            // Se todas as validações forem bem-sucedidas, criar o objeto Employee
            var employee = new Employee
            {
                EmployeeId = request.EmployeeId,
                Name = request.Name,
                Age = request.Age,
                Address = request.Address
            };
            
            // Armazena o registro no arquivo EMPLOYEE.DAT, preservando registros anteriores
            _employeeService.AddEmployee(employee);
            
            // Retorna a mensagem de confirmação após a inserção bem-sucedida
            return Ok("Employee record added");
        }
    }
}
