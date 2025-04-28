namespace MyProject.Models
{
    public class EmployeeRequest
    {
        // Deve ser composto por exatamente 4 dígitos numéricos
        public string EmployeeId { get; set; }

        // Até 20 caracteres
        public string Name { get; set; }

        // Deve conter 2 dígitos numéricos
        public string Age { get; set; }

        // Até 30 caracteres
        public string Address { get; set; }
    }
}
