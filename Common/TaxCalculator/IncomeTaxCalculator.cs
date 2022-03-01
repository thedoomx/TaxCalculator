namespace Common.TaxCalculator
{
	public class IncomeTaxCalculator : TaxCalculator
	{
		public override TaxCalculatorResult CalculateTax(TaxCalculatorResult result)
		{
			if (result.TotalRemaining > CalculatorConstants.IncomeTaxLowerCutOff)
			{
				result.IncomeTax = result.TotalRemaining * CalculatorConstants.IncomeTaxPercentage;
				result.TotalRemaining -= result.IncomeTax.Value;
			}

			if (Next != null)
			{
				return Next.CalculateTax(result);
			}

			return result;
		}
	}
}
