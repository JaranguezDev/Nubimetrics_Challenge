using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Nubimetrics_ChallengeCurrencies.Services.Helpers
{
    internal class WebApiCaller
    {
        private readonly string _baseUrl;

        public WebApiCaller(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<T> ExecuteGetAsync<T>(string apiMethod = null, string parameter = null)
        {
            try
            {
                var completeUrl = string.Concat(_baseUrl, apiMethod ?? "", parameter ?? "");

                using var httpClient = new HttpClient();
                using var response = await httpClient.GetAsync(completeUrl);

                string apiResponse = await response.Content.ReadAsStringAsync();
                
                return JsonConvert.DeserializeObject<T>(apiResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
