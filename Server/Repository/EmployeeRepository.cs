using Microsoft.EntityFrameworkCore;

using TestBlazorApp.Server.Contracts;
using TestBlazorApp.Server.Data;
using TestBlazorApp.Server.Models;

namespace TestBlazorApp.Server.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync() => await _context.Employees.ToListAsync();

        public async Task<Employee> GetEmployeeAsync(Guid id) => await _context.Employees
            .SingleOrDefaultAsync(e => e.Id.Equals(id));

        public async Task CreateEmployeeAsync(Employee employee)
        {
            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
        }
    }
}
