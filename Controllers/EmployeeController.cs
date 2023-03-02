using Microsoft.AspNetCore.Mvc;
using SalesDataPredictionAPI.Models.Data;
using SalesDataPredictionAPI.Models.Repository;

namespace SalesDataPredictionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;

        [HttpGet]
        [ActionName(nameof(GetEmployeesAsync))]
        public IEnumerable<Employee> GetEmployeesAsync()
        {
            return _employeeRepository.GetAsync();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetEmployeeById))]
        public ActionResult<Employee> GetEmployeeById(int id)
        {
            var employeeById = _employeeRepository.GetByIdAsync(id);
            if (employeeById == null)
                return NotFound();

            return employeeById;
        }
    }
}
