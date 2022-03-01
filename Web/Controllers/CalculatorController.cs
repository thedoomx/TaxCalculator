using Application.Commands.CalculateTax;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Web.Controllers
{
	public class CalculatorController : ApiController
	{
        [HttpPost]
        public async Task<ActionResult<CalculateTaxOutputModel>> GetDepartments(
            [FromBody] CalculateTaxCommand command)
            => await this.Send(command);
    }
}
