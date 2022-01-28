using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nubimetrics_ChallengeCurrencies.Services.Currency.Dtos
{
    public partial class CurrencyConversionDto
    {
        [JsonProperty("currency_base")]
        public string CurrencyBase { get; set; }

        [JsonProperty("currency_quote")]
        public string CurrencyQuote { get; set; }

        [JsonProperty("ratio")]
        public double Ratio { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("inv_rate")]
        public double InvRate { get; set; }

        [JsonProperty("creation_date")]
        public DateTimeOffset CreationDate { get; set; }

        [JsonProperty("valid_until")]
        public DateTimeOffset ValidUntil { get; set; }
    }
}
