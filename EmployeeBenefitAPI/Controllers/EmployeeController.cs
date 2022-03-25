#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeBenefitAPI.Models;
using EmployeeBenefitAPI.Core.IConfiguration;

namespace EmployeeBenefitAPI.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(
            ILogger<EmployeeController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _unitOfWork.Employees.All();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(Guid id)
        {
           var employee = await _unitOfWork.Employees.GetById(id);

          if(employee == null)
              return NotFound();

          return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, Employee employee)
        {
            if(id != employee.Id)
              return BadRequest();

          await _unitOfWork.Employees.Upsert(employee);
          await _unitOfWork.CompleteAsync();

          return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
          
              employee.Id = Guid.NewGuid();

              await _unitOfWork.Employees.Add(employee);
              await _unitOfWork.CompleteAsync();

              return CreatedAtAction("GetEmployee", new {employee.Id}, employee);
          
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var item = await _unitOfWork.Employees.GetById(id);

            if(item == null)
                return BadRequest();

            await _unitOfWork.Employees.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }
    }
}
