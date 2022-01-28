using System;

namespace Nubimetrics_Challenge.MeLiClient
{
    public class MeLiClient
    {

    }

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
