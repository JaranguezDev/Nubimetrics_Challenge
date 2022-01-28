using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nubimetrics_Challenge.Services.Search.Interfaces;
using System.Threading.Tasks;

namespace Nubimetrics_Challenge.WebApi.Controllers
{
    [Route("api/Busqueda")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;
        private readonly ISearchService _searchService;

        public SearchController(
            ILogger<SearchController> logger,
            ISearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        [HttpGet("{criteria}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindProductsByCriteria(string criteria)
        {
            var productData = await _searchService.FindProductsByCriteria(criteria);

            if (productData.Status == 404)
                return NotFound();

            return Ok(productData);
        }
    }
}
