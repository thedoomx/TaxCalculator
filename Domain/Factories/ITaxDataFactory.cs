using Domain.Factories.Common;
using Domain.Models;

namespace Domain.Factories
{
	public interface ITaxDataFactory : IFactory<TaxData>
	{
		ITaxDataFactory WithFullName(string fullName);
		ITaxDataFactory WithSSN(string ssn);
		ITaxDataFactory WithGrossIncome(double grossIncome);
		ITaxDataFactory WithCharitySpent(double? charitySpent);
		ITaxDataFactory WithIncomeTax(double? incomeTax);
		ITaxDataFactory WithSocialTax(double? socialTax);
		ITaxDataFactory WithNetIncome(double netIncome);
	}
}
