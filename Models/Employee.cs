namespace MyProject.Models
{
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            // Serializa o objeto em um registro de texto com os campos separados por '|' 
            return $"{EmployeeId}|{Name}|{Age}|{Address}";
        }
    }
}
