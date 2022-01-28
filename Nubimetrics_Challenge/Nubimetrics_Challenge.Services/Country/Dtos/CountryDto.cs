using Newtonsoft.Json;
using Nubimetrics_Challenge.Services.BaseService.Dtos;

namespace Nubimetrics_Challenge.Services.Country.Dtos
{
    public class CountryDto : BaseResponseDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("currency_id")]
        public string CurrencyId { get; set; }

        [JsonProperty("decimal_separator")]
        public string DecimalSeparator { get; set; }

        [JsonProperty("thousands_separator")]
        public string ThousandsSeparator { get; set; }

        [JsonProperty("time_zone")]
        public string TimeZone { get; set; }

        [JsonProperty("geo_information")]
        public GeoInformation GeoInformation { get; set; }

        [JsonProperty("states")]
        public State[] States { get; set; }
    }

    public class GeoInformation
    {
        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class Location
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }

    public class State
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}