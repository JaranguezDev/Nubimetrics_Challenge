using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nubimetrics_ChallengeCurrencies.Services.Currency.Dtos
{
    public partial class CurrencyDto
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("decimal_places")]
        public long DecimalPlaces { get; set; }

        [JsonProperty("todolar")]
        public double ToDolar { get; set; }
    }
}
