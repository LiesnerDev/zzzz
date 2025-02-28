using System.ComponentModel.DataAnnotations;

namespace Employee.Application.Employees.Models
{
    public class EmployeeRequest
    {
        public long Id { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z]{1,20}$", ErrorMessage = "Name must be up to 20 alphabetic characters.")]
        public string Name { get; set; }

        [Range(10, 99, ErrorMessage = "Age must be a two-digit number.")]
        public int Age { get; set; }

        [Required]
        [RegularExpression("^[A-Za-z ]{1,30}$", ErrorMessage = "Address must be up to 30 alphabetic characters.")]
        public string Address { get; set; }
    }
}