namespace Common.TaxCalculator
{
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class SocialContributionsTaxCalculatorSpecs
    {
        [Fact]
        public void LetThanCutOffSocialContributionsShouldNotHaveTaxValue()
        {
            // Arrange
            var socialContributionsTaxCalculator = new SocialContributionsTaxCalculator();
            var taxCalculatorResult = new TaxCalculatorResult(980);

            // Act
            socialContributionsTaxCalculator.CalculateTax(taxCalculatorResult);

            // Assert
            taxCalculatorResult.SocialTax.Should().NotHaveValue();
        }

        [Fact]
        public void AboveCutOffSocialContributionsNotShouldHaveTaxValue()
        {
            // Arrange
            var grossIncome = 3400;
            var socialContributionsTaxCalculator = new SocialContributionsTaxCalculator();
            var taxCalculatorResult = new TaxCalculatorResult(grossIncome);

            // Act
            socialContributionsTaxCalculator.CalculateTax(taxCalculatorResult);

            // Assert
            taxCalculatorResult.SocialTax.Should().BeNull();
        }

        [Fact]
        public void SocialContributionsShouldHaveTaxValueFifteenPercent()
        {
            // Arrange
            var grossIncome = 2000;
            var socialContributionsTaxCalculator = new SocialContributionsTaxCalculator();
            var taxCalculatorResult = new TaxCalculatorResult(grossIncome);

            // Act
            socialContributionsTaxCalculator.CalculateTax(taxCalculatorResult);

            // Assert
            taxCalculatorResult.SocialTax.Should().Be(grossIncome * 0.15);
        }
    }
}
