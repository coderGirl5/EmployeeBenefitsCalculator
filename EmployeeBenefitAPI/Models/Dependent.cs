namespace EmployeeBenefitAPI.Models
{
    public class Dependent : Person
    {
        public Guid Id { get; set; }
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
        BenefitCalculator benefitCalculator = new BenefitCalculator();
        
        public Dependent()
        {
            benefitCalculator.CoverageCost = 500;
        }
    }
}