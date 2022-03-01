using Domain.Models;

namespace Domain.Factories
{
	internal class TaxDataFactory : ITaxDataFactory
	{
		private string fullName = default!;
		private string ssn = default!;
		private double grossIncome = default!;
		private double? charitySpent = default!;
		private double? incomeTax = default!;
		private double? socialTax = default!;
		private double netIncome = default!;

		public ITaxDataFactory WithFullName(string fullName)
		{
			this.fullName = fullName;
			return this;
		}

		public ITaxDataFactory WithSSN(string ssn)
		{
			this.ssn = ssn;
			return this;
		}

		public ITaxDataFactory WithGrossIncome(double grossIncome)
		{
			this.grossIncome = grossIncome;
			return this;
		}

		public ITaxDataFactory WithCharitySpent(double? charitySpent)
		{
			this.charitySpent = charitySpent;
			return this;
		}


		public ITaxDataFactory WithIncomeTax(double? incomeTax)
		{
			this.incomeTax = incomeTax;
			return this;
		}


		public ITaxDataFactory WithSocialTax(double? socialTax)
		{
			this.socialTax = socialTax;
			return this;
		}

		public ITaxDataFactory WithNetIncome(double netIncome)
		{
			this.netIncome = netIncome;
			return this;
		}

		public TaxData Build()
		{
			var result = new TaxData(this.fullName, this.ssn, this.grossIncome, this.charitySpent, this.incomeTax, this.socialTax, this.netIncome);

			return result;
		}
	}
}
