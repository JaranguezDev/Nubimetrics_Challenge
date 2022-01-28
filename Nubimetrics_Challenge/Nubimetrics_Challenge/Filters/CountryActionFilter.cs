using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace Nubimetrics_Challenge.WebApi.Filters
{
    public class CountryActionFilter : IActionFilter
    {
        private readonly IConfiguration _configuration;

        public CountryActionFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnActionExecuted(ActionExecutedContext context) { }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var countryCode = context.ActionArguments["countryCode"]?.ToString();

            var unauthorizedCountryCodes = _configuration["UnauthorizedCountryCodes"]?.Split(',').ToList();

            if (!string.IsNullOrEmpty(countryCode) &&
                unauthorizedCountryCodes.Any() &&
                unauthorizedCountryCodes.Contains(countryCode))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
