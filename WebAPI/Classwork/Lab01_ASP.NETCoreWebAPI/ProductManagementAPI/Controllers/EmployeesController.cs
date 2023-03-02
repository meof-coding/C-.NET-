using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bussiness_Object.DataAccess;
using Repositories;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeRepository repository = new EmployeeRepository();
        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return Ok(repository.GetEmployees());
        }

        // GET: api/Employees/5
        [HttpGet("get/{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = repository.GetEmployee(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
    }
}
