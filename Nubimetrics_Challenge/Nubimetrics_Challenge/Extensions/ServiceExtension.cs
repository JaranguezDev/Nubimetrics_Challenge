using Microsoft.Extensions.DependencyInjection;
using Nubimetrics_Challenge.Services.Country.Interfaces;
using Nubimetrics_Challenge.Services.Country.Services;
using Nubimetrics_Challenge.Services.Search.Interfaces;
using Nubimetrics_Challenge.Services.Search.Services;
using Nubimetrics_Challenge.Services.User.Interfaces;
using Nubimetrics_Challenge.Services.User.Services;
using Nubimetrics_Challenge.WebApi.Filters;

namespace Nubimetrics_Challenge.WebApi.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<CountryActionFilter>();

            return services;
        }
    }
}
