using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using EmployeeBenefitAPI.Models;

namespace EmployeeBenefitAPI.Data
{
    public class BenefitManagementContext : DbContext
    {
        public BenefitManagementContext(DbContextOptions<BenefitManagementContext> options)
            : base(options)
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees  { get; set; } = null!;
        public DbSet<Dependent> Dependents { get; set;} = null!;
    }
}