using System.ComponentModel.DataAnnotations;

namespace Ch02FutueValueAnderson.Models
{
    public class FutureValueModel
    {
        [Required(ErrorMessage = "Please enter a monthly investment.")]
        [Range(1, 500, ErrorMessage = "Monthly investment must be between 1 and 500.")]
        public decimal MonthlyInvestment { get; set; }
        [Required(ErrorMessage = "Please enter a yearly interest rate.")]
        [Range(0.1, 10.0, ErrorMessage = "Yearly interest rate must be between 0.1 and 10.0.")]
        public decimal YearlyInvestment { get; set; }
        [Required(ErrorMessage = "Please enter the number of years.")]
        [Range(1, 50, ErrorMessage = "Number of years must be between 1 and 50.")]
        public int? Years { get; set; }
        public decimal CalculateFutureValue()
        {
            int months = Years.Value * 12;
            decimal monthlyInterestRate = YearlyInvestment / 12 / 100;
            decimal futureValue = 0;
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + MonthlyInvestment) *
                    (1 + YearlyInvestment);
            }
            return futureValue;
        }
    }
}
