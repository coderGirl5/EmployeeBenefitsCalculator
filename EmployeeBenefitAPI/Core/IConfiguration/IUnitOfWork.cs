using EmployeeBenefitAPI.Core.IRepositories;
namespace EmployeeBenefitAPI.Core.IConfiguration
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IDependentRepository Dependents { get; }

        Task CompleteAsync();
    }
}