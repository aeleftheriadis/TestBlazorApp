using TestBlazorApp.Server.Models;

namespace TestBlazorApp.Server.Contracts
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee> GetEmployeeAsync(Guid id);
        Task CreateEmployeeAsync(Employee employee);
    }
}
