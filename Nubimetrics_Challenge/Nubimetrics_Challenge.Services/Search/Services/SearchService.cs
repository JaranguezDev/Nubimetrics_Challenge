using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nubimetrics_Challenge.Services.Helpers;
using Nubimetrics_Challenge.Services.Search.Dtos;
using Nubimetrics_Challenge.Services.Search.Interfaces;
using System;
using System.Threading.Tasks;

namespace Nubimetrics_Challenge.Services.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly ILogger<SearchService> _logger;
        private readonly IConfiguration _configuration;

        private readonly WebApiCaller _webApiCaller;

        public SearchService(
            ILogger<SearchService> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _webApiCaller = new WebApiCaller(_configuration["MlApiUrl"]);
        }

        public async Task<SearchDto> FindProductsByCriteria(string criteria)
        {
            var result = new SearchDto();

            try
            {
                var getProductDataEndpoint = "sites/MLA/search?q=";
                result = await _webApiCaller.ExecuteGetAsync<SearchDto>(getProductDataEndpoint, criteria);
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
