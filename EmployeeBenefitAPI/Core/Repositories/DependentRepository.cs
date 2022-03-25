using EmployeeBenefitAPI.Models;
using EmployeeBenefitAPI.Core.IRepositories;
using EmployeeBenefitAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBenefitAPI.Core.Repositories
{
    public class DependentRepository : GenericRepository<Dependent>, IDependentRepository
    {
        
         public DependentRepository(BenefitManagementContext context, ILogger logger) : base(context, logger) { }

        public override async Task<IEnumerable<Dependent>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(EmployeeRepository));
                return new List<Dependent>();
            }
        }

        public override async Task<Dependent> GetById(Guid id)
        {
             try
            {
                return await dbSet.Where(x=>x.Id==id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(DependentRepository));
                return new Dependent();
            }
        }

        public override async Task<bool> Upsert(Dependent entity)
        {
            try
            {
                var existingDependent = await dbSet.Where(x => x.Id == entity.Id)
                                                    .FirstOrDefaultAsync();

                if (existingDependent == null)
                    return await Add(entity);

                existingDependent.FirstName = entity.FirstName;
                existingDependent.LastName = entity.LastName;

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