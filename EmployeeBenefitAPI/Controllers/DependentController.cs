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
    [Route("api/dependent")]
    [ApiController]
    public class DependentController : ControllerBase
    {
        private readonly ILogger<DependentController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public DependentController(
            ILogger<DependentController> logger,
            IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dependents = await _unitOfWork.Dependents.All();
            return Ok(dependents);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Dependent>> GetDependent(Guid id)
        {
            var dependent = await _unitOfWork.Dependents.GetById(id);

          if(dependent == null)
              return NotFound();

          return Ok(dependent);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDependent(Guid id, Dependent dependent)
        {
            if(id != dependent.Id)
              return BadRequest();

          await _unitOfWork.Dependents.Upsert(dependent);
          await _unitOfWork.CompleteAsync();

          return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Dependent>> PostDependent(Dependent dependent)
        {
            dependent.Id = Guid.NewGuid();
            //make sure the associated employee id is valid
            var employee = await _unitOfWork.Employees.GetById(dependent.EmployeeId);
            if(employee==null)
            {
                return BadRequest();
            }
            dependent.Employee=employee;
            await _unitOfWork.Dependents.Add(dependent);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction("GetDependent", new {dependent.Id}, dependent);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDependent(Guid id)
        {
            var item = await _unitOfWork.Dependents.GetById(id);

            if(item == null)
                return BadRequest();

            await _unitOfWork.Dependents.Delete(id);
            await _unitOfWork.CompleteAsync();

            return Ok(item);
        }
    }
}
