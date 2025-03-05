using System;
using System.IO;
using EmployeeRegistration.Models;

namespace EmployeeRegistration.Services
{
    public static class EmployeeService
    {
        private static readonly string filePath = "EMPLOYEE.DAT";

        public static void AddEmployee(Employee employee)
        {
            // Formata os dados para salvar no arquivo
            // Exemplo: 1234,Nome,25,Endereco
            var record = $"{employee.Id},{employee.Name},{employee.Age},{employee.Address}";
            
            try
            {
                // Abre ou cria o arquivo e adiciona o registro ao final
                using (var writer = new StreamWriter(filePath, append: true))
                {
                    writer.WriteLine(record);
                }
            }
            catch (Exception ex)
            {
                // Lida com exceções de I/O
                throw new Exception("Erro ao escrever no arquivo: " + ex.Message);
            }
        }
    }
}
