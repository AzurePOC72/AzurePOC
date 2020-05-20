using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/Employee
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var employees = _employeeRepository.GetAllEmployees();
            OkObjectResult okObjectResult = new OkObjectResult(employees);
            return employees;
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public Employee Get(int id)
        {
            id = id <= 0 ? 1 : id;
            var employee = _employeeRepository.GetEmployeeByID(id);

            if (employee == null)
            {
                return null;
            }

            return employee;
        }

        // POST: api/Employee
        [HttpPost]
        public Employee Post([FromBody] Employee value)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeRepository.Add(value);
                if (employee == null)
                {
                    return null;
                }

                return employee; 
            }
            return null;
        }

        // PUT: api/Employee
        [HttpPut("{id}")]
        public Employee Put(int id, [FromBody] Employee value)
        {
            if (ModelState.IsValid && id == value.EmpId)
            {
                var employee = _employeeRepository.UpdateEmployee(value);
                if (employee == null)
                {
                    return null;
                }

                return employee;
            }

            return null;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var employee = _employeeRepository.Delete(id);

            if (employee == null)
            {
                BadRequestObjectResult badRequestObjectResult = new BadRequestObjectResult("Unable to process the Request");
                return BadRequest(badRequestObjectResult);
            }
            return NoContent();
        }
    }
}
