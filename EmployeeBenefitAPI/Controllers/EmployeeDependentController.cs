#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeBenefitAPI.Models;

namespace EmployeeBenefitAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDependentController : ControllerBase
    {
        private readonly BenefitManagementContext _context;

        public EmployeeDependentController(BenefitManagementContext context)
        {
            _context = context;
        }

        // GET: api/EmployeeDependent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDependent>>> GetEmployeeDependent()
        {
            return await _context.EmployeeDependent.ToListAsync();
        }

        // GET: api/EmployeeDependent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDependent>> GetEmployeeDependent(long id)
        {
            var employeeDependent = await _context.EmployeeDependent.FindAsync(id);

            if (employeeDependent == null)
            {
                return NotFound();
            }

            return employeeDependent;
        }

        // PUT: api/EmployeeDependent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeDependent(long id, EmployeeDependent employeeDependent)
        {
            if (id != employeeDependent.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeDependent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDependentExists(id))
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

        // POST: api/EmployeeDependent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeDependent>> PostEmployeeDependent(EmployeeDependent employeeDependent)
        {
            _context.EmployeeDependent.Add(employeeDependent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeDependent", new { id = employeeDependent.Id }, employeeDependent);
        }

        // DELETE: api/EmployeeDependent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeDependent(long id)
        {
            var employeeDependent = await _context.EmployeeDependent.FindAsync(id);
            if (employeeDependent == null)
            {
                return NotFound();
            }

            _context.EmployeeDependent.Remove(employeeDependent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeDependentExists(long id)
        {
            return _context.EmployeeDependent.Any(e => e.Id == id);
        }
    }
}
