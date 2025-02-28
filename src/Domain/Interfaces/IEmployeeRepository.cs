using Employee.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Domain.Interfaces
{
    public interface IEmployeeRepository : IRepository<EmployeeRecord>
    {
        Task<EmployeeRecord> GetByIdAsync(long id);
        Task<IEnumerable<EmployeeRecord>> GetAllAsync();
    }
}