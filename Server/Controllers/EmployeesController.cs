using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TestBlazorApp.Server.Contracts;
using TestBlazorApp.Server.Models;

namespace TestBlazorApp.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();

            if(employees?.Any() == false)
            {
                return NoContent();
            }

            return Ok(employees);
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeAsync([FromQuery] Guid employeeId)
        {
            var employee = await _employeeRepository.GetEmployeeAsync(employeeId);
            if(employee == null)
            {
                return NoContent();
            }

            return Ok(employee);
        }

        public async Task<IActionResult> AddEmployee([FromBody] Employee model)
        {
            await _employeeRepository.CreateEmployeeAsync(model);
            return Ok();
        }
    }
}
