namespace Common.TaxCalculator
{
	public class TaxCalculatorResult
	{
		public TaxCalculatorResult(double totalRemaining)
		{
			this.TotalRemaining = totalRemaining;
		}

		public double? CharityTax { get; set; }

		public double? IncomeTax { get; set; }

		public double? SocialTax { get; set; }

		public double TotalRemaining { get; set; }
	}
}
