namespace Common.TaxCalculator
{
    public abstract class TaxCalculator
    {
        protected TaxCalculator Next;

        public void SetNext(TaxCalculator next)
        {
            Next = next;
        }

        public abstract TaxCalculatorResult CalculateTax(TaxCalculatorResult result);
    }
}
