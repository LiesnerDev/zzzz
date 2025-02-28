namespace Employee.Application.Employees.Models
{
    public class EmployeeResponse : BaseResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public static implicit operator EmployeeResponse(Domain.Entities.EmployeeRecord employee)
        {
            if (employee == null) return new EmployeeResponse();
            return new EmployeeResponse
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address
            };
        }
    }
}