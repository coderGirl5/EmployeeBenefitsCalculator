namespace EmployeeBenefitAPI.Models
{
    public class Employee
    {
        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal? TotalBenefitCost { get; set; }
        public decimal? EmployeeBenefitCost { get; set; }
        public decimal? TotalDependentBenefitCost { get; set; }

    }
}