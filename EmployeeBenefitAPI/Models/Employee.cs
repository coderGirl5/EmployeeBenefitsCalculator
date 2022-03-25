namespace EmployeeBenefitAPI.Models
{
    public class Employee : Person
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public decimal? BasePay { get; set; }

        BenefitCalculator benefitCalculator = new BenefitCalculator();

        public Employee()
        {
            benefitCalculator.CoverageCost=1000;
        }
    }
}