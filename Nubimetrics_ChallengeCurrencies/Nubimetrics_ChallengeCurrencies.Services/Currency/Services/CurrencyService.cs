using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Nubimetrics_ChallengeCurrencies.Services.Currency.Dtos;
using Nubimetrics_ChallengeCurrencies.Services.Currency.Interfaces;
using Nubimetrics_ChallengeCurrencies.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nubimetrics_ChallengeCurrencies.Services.Currency.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ILogger<CurrencyService> _logger;
        private readonly IConfiguration _configuration;

        private readonly string _currenciesUrl = "currencies";
        private readonly string _currencyConversionsUrl = "currency_conversions/search?from={0}&to=USD";
        private readonly WebApiCaller _webApiCaller;

        public CurrencyService(
            ILogger<CurrencyService> logger,
            IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _webApiCaller = new WebApiCaller(_configuration["MlApiUrl"]);
        }

        public async Task ProcessCurrencyConversion()
        {
            var ratioList = new List<string>();

            try
            {
                var currencies = await GetCurrencies();

                ratioList = await SetAndGetCurrencyToDolarProperty(currencies);

                await SaveRatioListToFile(ratioList);

                await SaveCurrenciesWithRatioToFile(currencies);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }

        private async Task SaveCurrenciesWithRatioToFile(IList<CurrencyDto> currencies)
        {
            try
            {
                var fileName = "CurrenciesWithRatio.json";
                var jsonFileOutputPath = _configuration["FilesOutputPath"];

                var dataToSave = JsonSerializer.Serialize(currencies, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                });

                var result = await FileProcessor.SaveToFile(dataToSave, jsonFileOutputPath, fileName);

                if (!result)
                    _logger.LogError($"No fue posible guardar el archivo: '{fileName}'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task SaveRatioListToFile(List<string> ratioList)
        {
            try
            {
                var fileName = "CurrenciesRatio.csv";
                var csvFileOutputPath = _configuration["FilesOutputPath"];

                var dataToSave = string.Join(",", ratioList);
                var result = await FileProcessor.SaveToFile(dataToSave, csvFileOutputPath, fileName);

                if (!result)
                    _logger.LogError($"No fue posible guardar el archivo: '{fileName}'");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<List<string>> SetAndGetCurrencyToDolarProperty(IList<CurrencyDto> currencies)
        {
            var ratioList = new List<string>();

            try
            {
                foreach(var currency in currencies)
                {
                    var formatUrl = string.Format(_currencyConversionsUrl, currency.Id);
                    var currencyConversion = await _webApiCaller.ExecuteGetAsync<CurrencyConversionDto>(formatUrl);
                    ratioList.Add(currencyConversion.Ratio.ToString());
                    currency.ToDolar = currencyConversion.Ratio;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }

            return ratioList;
        }

        private async Task<IList<CurrencyDto>> GetCurrencies()
        {
            try
            {
                return await _webApiCaller.ExecuteGetAsync<IList<CurrencyDto>>(_currenciesUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
    }
}
