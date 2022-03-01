using Application.Commands.CalculateTax;
using System.Threading.Tasks;

namespace Application.Services.Contracts
{
	public interface ITaxCalculationService
	{
		Task<CalculateTaxOutputModel> CalculateTax(CalculateTaxCommand calculateTaxCommand);
	}
}
