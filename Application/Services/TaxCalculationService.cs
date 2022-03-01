using Application.Commands.CalculateTax;
using Application.Services.Contracts;
using Common.TaxCalculator;
using Domain.Factories;
using AutoMapper;
using System.Threading.Tasks;
using Infrastructure.Cache;

namespace Application.Services
{
	internal class TaxCalculationService : ITaxCalculationService
	{
		private readonly ITaxDataFactory _taxDataFactory;
		private readonly IMapper _mapper;
		private readonly ICacheService _cacheService;

		public TaxCalculationService(
				ITaxDataFactory taxDataFactory,
				IMapper mapper,
				ICacheService cacheService)
		{
			this._taxDataFactory = taxDataFactory;
			this._mapper = mapper;
			this._cacheService = cacheService;
		}

		public async Task<CalculateTaxOutputModel> CalculateTax(CalculateTaxCommand calculateTaxCommand)
		{
			var cachedResult = await this._cacheService.Get<CalculateTaxOutputModel>(calculateTaxCommand.SSN);
			if (cachedResult != null)
			{
				return cachedResult;
			}

			var charityTaxCalculator = new CharityTaxCalculator(calculateTaxCommand.CharitySpent);
			var socialTaxCalculator = new SocialContributionsTaxCalculator();
			var incomeTaxCalculator = new IncomeTaxCalculator();

			charityTaxCalculator.SetNext(incomeTaxCalculator);
			incomeTaxCalculator.SetNext(socialTaxCalculator);

			var taxCalculationResult = new TaxCalculatorResult(calculateTaxCommand.GrossIncome);
			taxCalculationResult = await Task.Run(() => charityTaxCalculator.CalculateTax(taxCalculationResult));

			var taxData = this._taxDataFactory
				.WithFullName(calculateTaxCommand.FullName)
				.WithSSN(calculateTaxCommand.SSN)
				.WithGrossIncome(calculateTaxCommand.GrossIncome)
				.WithCharitySpent(taxCalculationResult.CharityTax)
				.WithSocialTax(taxCalculationResult.SocialTax)
				.WithIncomeTax(taxCalculationResult.IncomeTax)
				.WithNetIncome(taxCalculationResult.TotalRemaining)
				.Build();

			var result = this._mapper.Map<CalculateTaxOutputModel>(taxData);
			await this._cacheService.Set<CalculateTaxOutputModel>(calculateTaxCommand.SSN, result);

			return result;
		}
	}
}
