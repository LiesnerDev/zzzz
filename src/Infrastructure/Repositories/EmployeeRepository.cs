using Employee.Domain.Entities;
using Employee.Domain.Interfaces;
using Employee.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(EmployeeRecord entity)
        {
            await _context.EmployeeRecords.AddAsync(entity);
        }

        public void Delete(EmployeeRecord entity)
        {
            _context.EmployeeRecords.Remove(entity);
        }

        public async Task<IEnumerable<EmployeeRecord>> GetAllAsync()
        {
            return await _context.EmployeeRecords.ToListAsync();
        }

        public async Task<EmployeeRecord> GetByIdAsync(long id)
        {
            return await _context.EmployeeRecords.FindAsync(id);
        }

        public void Update(EmployeeRecord entity)
        {
            _context.EmployeeRecords.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}