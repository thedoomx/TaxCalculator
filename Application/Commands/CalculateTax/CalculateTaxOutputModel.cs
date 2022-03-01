namespace Application.Commands.CalculateTax
{
	public class CalculateTaxOutputModel
	{
		public string FullName { get; set; }

		public string SSN { get; set; }

		public double GrossIncome { get; set; }

		public double? CharitySpent { get; set; }

		public double? IncomeTax { get; set; }

		public double? SocialTax { get; set; }

		public double? TotalTax { get; set; }

		public double NetIncome { get; set; }
	}
}
