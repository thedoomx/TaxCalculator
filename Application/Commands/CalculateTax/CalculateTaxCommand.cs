using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Common;
using Application.Services.Contracts;

namespace Application.Commands.CalculateTax
{
	public class CalculateTaxCommand : IRequest<Result<CalculateTaxOutputModel>>
	{
		public string FullName { get; set; } = default!;

		public string SSN { get; set; } = default!;

		public double GrossIncome { get; set; } = default!;

		public double? CharitySpent { get; set; }

		public class CalculateTaxCommandHandler : IRequestHandler<CalculateTaxCommand, Result<CalculateTaxOutputModel>>
		{
			private readonly ITaxCalculationService _taxCalculationService;
			public CalculateTaxCommandHandler(ITaxCalculationService taxCalculationService)
			{
				this._taxCalculationService = taxCalculationService;
			}

			public async Task<Result<CalculateTaxOutputModel>> Handle(
				CalculateTaxCommand request,
				CancellationToken cancellationToken)
				=> await this._taxCalculationService.CalculateTax(request);
		}
	}
}
