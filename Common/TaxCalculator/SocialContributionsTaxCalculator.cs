namespace Common.TaxCalculator
{
	public class SocialContributionsTaxCalculator : TaxCalculator
	{
		public override TaxCalculatorResult CalculateTax(TaxCalculatorResult result)
		{
			if (result.TotalRemaining > CalculatorConstants.SocialLowerCutOff &&
				result.TotalRemaining < CalculatorConstants.SocialHigherCutOff)
			{
				result.SocialTax = result.TotalRemaining * CalculatorConstants.SocialTaxPercentage;
				result.TotalRemaining -= result.SocialTax.Value;
			}

			if (Next != null)
			{
				return Next.CalculateTax(result);
			}

			return result;
		}
	}
}
