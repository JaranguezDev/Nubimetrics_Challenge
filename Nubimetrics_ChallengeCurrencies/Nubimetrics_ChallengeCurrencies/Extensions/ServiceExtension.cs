using Microsoft.Extensions.DependencyInjection;
using Nubimetrics_ChallengeCurrencies.Services.Currency.Interfaces;
using Nubimetrics_ChallengeCurrencies.Services.Currency.Services;

namespace Nubimetrics_ChallengeCurrencies.WebApi.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyService, CurrencyService>();

            return services;
        }
    }
}
