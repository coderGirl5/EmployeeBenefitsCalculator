namespace EmployeeBenefitAPI.Models
{
    public class EmployeeDependent
    {
        public long Id { get; set; }
        public int EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal? TotalBenefitCost { get; set; }

    }
}