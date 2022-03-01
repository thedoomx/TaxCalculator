namespace Common.TaxCalculator
{
    using FakeItEasy;
    using FluentAssertions;
    using Xunit;

    public class IncomeTaxCalculatorSpecs
    {
        [Fact]
        public void LetThanCutOffIncomeShouldNotHaveTaxValue()
        {
            // Arrange
            var incomeTaxCalculator = new IncomeTaxCalculator();
            var taxCalculatorResult = new TaxCalculatorResult(980);

            // Act
            incomeTaxCalculator.CalculateTax(taxCalculatorResult);

            // Assert
            taxCalculatorResult.IncomeTax.Should().NotHaveValue();
        }

        [Fact]
        public void AboveCutOffIncomeShouldHaveTaxValueTenPercent()
        {
            // Arrange
            var grossIncome = 3400;
            var incomeTaxCalculator = new IncomeTaxCalculator();
            var taxCalculatorResult = new TaxCalculatorResult(grossIncome);

            // Act
            incomeTaxCalculator.CalculateTax(taxCalculatorResult);

            // Assert
            taxCalculatorResult.IncomeTax.Should().Be(grossIncome * 0.1);
        }
    }
}
