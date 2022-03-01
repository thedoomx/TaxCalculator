using Bogus;

namespace Common.TaxCalculator
{
    public class TaxCalculatorResultFakes
    {
        public static class Data
        {
            public static TaxCalculatorResult GetTaxCalculatorResult(double totalRemaining)
            {
                var taxCalculatorResult = new Faker<TaxCalculatorResult>()
                    .CustomInstantiator(f => new TaxCalculatorResult(
                        totalRemaining
                      ))
                    .Generate();

              
                return taxCalculatorResult;
            }
        }
    }
}
