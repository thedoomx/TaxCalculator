namespace Application.Commands.CalculateTax
{
    using FluentValidation;
    using static Domain.Models.ModelConstants.TaxData;


    public class CalculateTaxCommandValidator : AbstractValidator<CalculateTaxCommand>
    {
        public CalculateTaxCommandValidator()
        {
            this.RuleFor(u => u.FullName)
                .MinimumLength(MinFullNameLength)
                .MaximumLength(MaxFullNameLength)
                .NotEmpty();

            this.RuleFor(u => u.SSN)
                .Matches(SSNRegularExpression)
                .NotEmpty();

            this.RuleFor(u => u.GrossIncome)
                .NotEmpty();
        }
    }
}
