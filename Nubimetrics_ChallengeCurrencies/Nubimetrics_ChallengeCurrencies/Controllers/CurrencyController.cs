using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nubimetrics_ChallengeCurrencies.Services.Currency.Interfaces;
using System.Threading.Tasks;

namespace Nubimetrics_ChallengeCurrencies.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(
            ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> ProcessCurrencyConversion()
        {
            await _currencyService.ProcessCurrencyConversion();
            return Ok();
        }
    }
}
