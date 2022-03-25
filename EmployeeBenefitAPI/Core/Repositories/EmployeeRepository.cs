using EmployeeBenefitAPI.Models;
using EmployeeBenefitAPI.Core.IRepositories;
using EmployeeBenefitAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefitAPI.Core.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(BenefitManagementContext context, ILogger logger) : base(context, logger) { }

        public override async Task<IEnumerable<Employee>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(EmployeeRepository));
                return new List<Employee>();
            }
        }

        public override async Task<Employee> GetById(Guid id)
        {
             try
            {
                return await dbSet.Where(x=>x.Id==id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(EmployeeRepository));
                return new Employee();
            }
        }

        public override async Task<bool> Upsert(Employee entity)
        {
            try
            {
                var existingEmployee = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existingEmployee == null)
                    return await Add(entity);

                existingEmployee.FirstName = entity.FirstName;
                existingEmployee.LastName = entity.LastName;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(EmployeeRepository));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id)
                                        .FirstOrDefaultAsync();

                if (exist == null) return false;

                dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(EmployeeRepository));
                return false;
            }
        }
    }

}