using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nubimetrics_Challenge.Services.Country.Dtos;
using Nubimetrics_Challenge.Services.Country.Interfaces;
using Nubimetrics_Challenge.Services.Helpers;
using System;
using System.Threading.Tasks;

namespace Nubimetrics_Challenge.Services.Country.Services
{
    public class CountryService : ICountryService
    {
        private readonly ILogger<CountryService> _logger;
        private readonly IConfiguration _configuration;

        private readonly WebApiCaller _webApiCaller;

        public CountryService(
            ILogger<CountryService> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _webApiCaller = new WebApiCaller(_configuration["MlApiUrl"]);
        }

        public async Task<CountryDto> GetCountryByCode(string countryCode)
        {
            var result = new CountryDto();

            try
            {
                var getCountryDataEndpoint = "classified_locations/countries/";
                result = await _webApiCaller.ExecuteGetAsync<CountryDto>(getCountryDataEndpoint, countryCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }

            return result;
        }
    }
}
