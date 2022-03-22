using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using EmployeeBenefitAPI.Models;

namespace EmployeeBenefitAPI.Models
{
    public class BenefitManagementContext : DbContext
    {
        public BenefitManagementContext(DbContextOptions<BenefitManagementContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; } = null!;

        public DbSet<EmployeeBenefitAPI.Models.EmployeeDependent> EmployeeDependent { get; set; }
    }
}