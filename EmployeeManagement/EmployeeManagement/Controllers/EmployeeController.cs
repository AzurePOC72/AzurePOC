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
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            var employees = _employeeRepository.GetAllEmployees();
            OkObjectResult okObjectResult = new OkObjectResult(employees);
            return Ok(okObjectResult);
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            id = id <= 0 ? 1 : id;
            var employee = _employeeRepository.GetEmployeeByID(id);

            if (employee == null)
            {
                return NoContent();
            }

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<Employee>> Post([FromBody] Employee value)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeRepository.Add(value);
                if (employee == null)
                {
                    BadRequestObjectResult badRequestObjectResult = new BadRequestObjectResult("Unable to process the Request");
                    return BadRequest(badRequestObjectResult);
                }

                return Created("", employee); 
            }
            BadRequestObjectResult badRequestObjectResult1 = new BadRequestObjectResult(ModelState);
            return BadRequest(badRequestObjectResult1);
        }

        // PUT: api/Employee
        [HttpPut]
        public async Task<ActionResult<Employee>> Put([FromBody] Employee value)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeRepository.UpdateEmployee(value);
                if (employee == null)
                {
                    BadRequestObjectResult badRequestObjectResult = new BadRequestObjectResult("Unable to process the Request");
                    return BadRequest(badRequestObjectResult);
                }

                return Created("", employee); 
            }

            BadRequestObjectResult badRequestObjectResult1 = new BadRequestObjectResult(ModelState);
            return BadRequest(badRequestObjectResult1);
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
