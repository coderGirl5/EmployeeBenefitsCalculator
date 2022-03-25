using EmployeeBenefitAPI.Core.IConfiguration;
using EmployeeBenefitAPI.Core.IRepositories;
using EmployeeBenefitAPI.Core.Repositories;
namespace EmployeeBenefitAPI.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BenefitManagementContext _context;
        private readonly ILogger _logger;

        public IEmployeeRepository Employees { get; private set; }
        public IDependentRepository Dependents  { get; private set; }


        public UnitOfWork(BenefitManagementContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Employees = new EmployeeRepository(context, _logger);
            Dependents = new DependentRepository(context,_logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}