namespace EmployeeBenefitAPI.Models
{
    public class BenefitCalculator
    {
        public decimal CoverageCost { get; set; }
        private decimal firstNameBeginsWithADiscount = 0.1M;
        
        public decimal CalculateCoverageAmount(Person person){
            if(person==null)
            {
                throw new Exception("Need to have a valid person before doing any calculations");
            }
            if(person.FirstName==null)
            {
                throw new Exception("Unable to calculate possible discount without the person first name");
            }

            decimal totalCoverageCost = this.CoverageCost;
            if(person.FirstName.ToLower().StartsWith('a'))
            {
                //give a discount
                totalCoverageCost = totalCoverageCost -  (totalCoverageCost * firstNameBeginsWithADiscount);
            }
            
            return totalCoverageCost;
        }
    }
}