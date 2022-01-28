using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nubimetrics_Challenge.Services.Country.Dtos;
using Nubimetrics_Challenge.Services.Country.Interfaces;
using Nubimetrics_Challenge.WebApi.Filters;
using System.Threading.Tasks;

namespace Nubimetrics_Challenge.WebApi.Controllers
{
    [Route("api/Paises")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(
            ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet("{countryCode}")]
        [ServiceFilter(typeof(CountryActionFilter))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CountryDto>> GetCountryByCode(string countryCode)
        {
            var countryData = await _countryService.GetCountryByCode(countryCode);

            if (countryData.Status == 404)
                return NotFound();

            return Ok(countryData);
        }
    }
}
