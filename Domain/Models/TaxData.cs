using Domain.Validation;
using static Domain.Models.ModelConstants.TaxData;

namespace Domain.Models
{
	public class TaxData
	{
		public TaxData
			(string fullName, string ssn, double grossIncome, double? charitySpent, double? incomeTax, double? socialTax, double netIncome)
		{
			this.Validate(fullName, ssn);

			this.FullName = fullName;
			this.SSN = ssn;
			this.GrossIncome = grossIncome;
			this.CharitySpent = charitySpent;
			this.IncomeTax = incomeTax;
			this.SocialTax = socialTax;
			this.NetIncome = netIncome;
			this.TotalTax = this.SetTotalTax();
		}

		public string FullName { get; private set; }

		public string SSN { get; private set; }

		public double GrossIncome { get; private set; }

		public double? CharitySpent { get; private set; }

		public double? IncomeTax { get; private set; }

		public double? SocialTax { get; private set; }

		public double? TotalTax { get; private set; }

		public double NetIncome { get; private set; }

		private double? SetTotalTax()
		{
			return (this.SocialTax ?? 0) + (this.IncomeTax ?? 0);
		}

		private void Validate(string fullName, string ssn)
		{
			this.ValidateFullName(fullName);
			this.ValidateSSN(ssn);
		}

		private void ValidateFullName(string fullName)
		{
			Guard.ForStringLength<InvalidTaxDataException>(
				fullName,
				MinFullNameLength,
				MaxFullNameLength,
				nameof(this.FullName));

			Guard.ForRegex<InvalidTaxDataException>(
				fullName,
				FullNameRegularExpression,
				nameof(this.FullName));
		}

		private void ValidateSSN(string ssn)
			=> Guard.ForRegex<InvalidTaxDataException>(
				ssn,
				SSNRegularExpression,
				nameof(this.SSN));
	}
}
