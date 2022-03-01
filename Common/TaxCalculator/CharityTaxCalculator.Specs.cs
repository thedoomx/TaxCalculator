namespace Common.TaxCalculator
{
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class CharityTaxCalculatorSpecs
    {
        [Fact]
        public void NullCharityShouldNotHaveTaxValue()
        {
            // Arrange
            var charityTaxCalculator = new CharityTaxCalculator(null);
            var taxCalculatorResult = new TaxCalculatorResult(980);

            // Act
            charityTaxCalculator.CalculateTax(taxCalculatorResult);

            // Assert
            taxCalculatorResult.CharityTax.Should().NotHaveValue();
        }

        [Fact]
        public void AboveCutOffCharityShouldTakeTenPercentTax()
        {
            // Arrange
            var grossIncome = 3600;
            var charityTaxCalculator = new CharityTaxCalculator(520);
            var taxCalculatorResult = new TaxCalculatorResult(grossIncome);

            // Act
            charityTaxCalculator.CalculateTax(taxCalculatorResult);

            // Assert
            taxCalculatorResult.CharityTax.Should().Be(grossIncome * 0.1);
        }

        [Fact]
        public void AboveCutOffCharityShouldNotTakeFullValue()
        {
            // Arrange
            var charityValue = 520;
            var grossIncome = 3600;
            var charityTaxCalculator = new CharityTaxCalculator(charityValue);
            var taxCalculatorResult = new TaxCalculatorResult(grossIncome);

            // Act
            charityTaxCalculator.CalculateTax(taxCalculatorResult);

            // Assert
            taxCalculatorResult.CharityTax.Should().NotBe(charityValue);
        }
    }
}
