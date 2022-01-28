using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Nubimetrics_Challenge.Services.BaseService.Dtos;
using System;
using System.Globalization;

namespace Nubimetrics_Challenge.Services.Search.Dtos
{
    public class SearchDto : BaseResponseDto
    {
        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("country_default_time_zone")]
        public string CountryDefaultTimeZone { get; set; }

        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("paging")]
        public Paging Paging { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }

        [JsonProperty("sort")]
        public Sort Sort { get; set; }

        [JsonProperty("available_sorts")]
        public Sort[] AvailableSorts { get; set; }

        [JsonProperty("filters")]
        public Filter[] Filters { get; set; }

        [JsonProperty("available_filters")]
        public AvailableFilter[] AvailableFilters { get; set; }
    }

    public class AvailableFilter
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("values")]
        public AvailableFilterValue[] Values { get; set; }
    }

    public class AvailableFilterValue
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("results")]
        public long Results { get; set; }
    }

    public class Sort
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Filter
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("values")]
        public FilterValue[] Values { get; set; }
    }

    public class FilterValue
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path_from_root", NullValueHandling = NullValueHandling.Ignore)]
        public Sort[] PathFromRoot { get; set; }
    }

    public class Paging
    {
        [JsonProperty("total")]
        public long Total { get; set; }

        [JsonProperty("primary_results")]
        public long PrimaryResults { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("limit")]
        public long Limit { get; set; }
    }

    public class Result
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("site_id")]
        public string SiteId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("seller")]
        public Seller Seller { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("permalink")]
        public Uri Permalink { get; set; }
    }

    public class Seller
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public enum TypeEnum { Boolean, List, Range, String, Text };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                TypeEnumConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "STRING":
                    return TypeEnum.String;
                case "boolean":
                    return TypeEnum.Boolean;
                case "list":
                    return TypeEnum.List;
                case "range":
                    return TypeEnum.Range;
                case "text":
                    return TypeEnum.Text;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            switch (value)
            {
                case TypeEnum.String:
                    serializer.Serialize(writer, "STRING");
                    return;
                case TypeEnum.Boolean:
                    serializer.Serialize(writer, "boolean");
                    return;
                case TypeEnum.List:
                    serializer.Serialize(writer, "list");
                    return;
                case TypeEnum.Range:
                    serializer.Serialize(writer, "range");
                    return;
                case TypeEnum.Text:
                    serializer.Serialize(writer, "text");
                    return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}