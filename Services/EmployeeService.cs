using System.IO;
using MyProject.Models;

namespace MyProject.Services
{
    public class EmployeeService
    {
        // O arquivo onde os registros dos funcionários serão armazenados
        private const string FilePath = "EMPLOYEE.DAT";
        
        public void AddEmployee(Employee employee)
        {
            // Cria ou abre o arquivo em modo de append, preservando registros existentes
            using (var writer = new StreamWriter(FilePath, true))
            {
                writer.WriteLine(employee.ToString());
            }
        }
    }
}
