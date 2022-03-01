using System;
using System.Collections.Generic;
using System.Text;

namespace Common.TaxCalculator
{
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class TaxCalculatorSpecs
    {
        [Fact]
        public void FlowTest()
        {
            // Arrange
            var grossIncome = 3600;
            var charitySpent = 520;
            var charityTaxCalculator = new CharityTaxCalculator(charitySpent);
            var socialTaxCalculator = new SocialContributionsTaxCalculator();
            var incomeTaxCalculator = new IncomeTaxCalculator();

            charityTaxCalculator.SetNext(incomeTaxCalculator);
            incomeTaxCalculator.SetNext(socialTaxCalculator);

            var taxCalculatorResult = new TaxCalculatorResult(grossIncome);

            // Act
            charityTaxCalculator.CalculateTax(taxCalculatorResult);

            // Assert
            taxCalculatorResult.TotalRemaining.Should().BeApproximately(2478, 0.6);
        }
	}
}
