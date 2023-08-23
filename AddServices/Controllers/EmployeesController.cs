using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AddServices.Data;
using AddServices.Models;
using Microsoft.AspNetCore.Authorization;

namespace AddServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AddServicesDbContext _context;

        public EmployeesController(AddServicesDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        // [Route("api/Employees/Getemployees")]
        [Route("Getemployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> Getemployees()
        {
            return await _context.employees.ToListAsync();
        }

        [Route("GetEmployee")]
        [HttpGet]
        // GET: api/Employees/5
       // [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            var employee = await _context.employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754

        [Route("PostEmployee")]
                [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee([FromForm]Employee employee)
        {
            _context.employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5

        [Route("DeleteEmployee")]
        [HttpDelete]
       // [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return _context.employees.Any(e => e.Id == id);
        }
    }
}
