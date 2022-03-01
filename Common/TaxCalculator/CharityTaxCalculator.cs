namespace Common.TaxCalculator
{
	public class CharityTaxCalculator : TaxCalculator
	{
		private readonly double? _charityValue;

		public CharityTaxCalculator(double? charityValue)
		{
			this._charityValue = charityValue;
		}

		public override TaxCalculatorResult CalculateTax(TaxCalculatorResult result)
		{
			if (this._charityValue.HasValue)
			{
				if (result.TotalRemaining * CalculatorConstants.CharityTaxCutOffPercentage < this._charityValue)
				{
					result.CharityTax = result.TotalRemaining * CalculatorConstants.CharityTaxPercentage;
				}
				else
				{
					result.CharityTax = this._charityValue;
				}

				result.TotalRemaining -= result.CharityTax.Value;
			}

			if (Next != null)
			{
				return Next.CalculateTax(result);
			}

			return result;
		}
	}
}
