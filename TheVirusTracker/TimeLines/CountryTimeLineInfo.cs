using COVID19.NET.Converters;
using System;
using System.Text.Json.Serialization;

namespace COVID19.NET.TheVirusTracker
{
    public struct CountryTimeLineInfo
    {
        [JsonPropertyName("countrycode")]
        public string CountryCode { get; set; }

        [JsonConverter(typeof(DateTimeConverter))]
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonConverter(typeof(StringToLongConverter))]
        [JsonPropertyName("cases")]
        public long Cases { get; set; }

        [JsonConverter(typeof(StringToLongConverter))]
        [JsonPropertyName("deaths")]
        public long Deaths { get; set; }

        [JsonConverter(typeof(StringToLongConverter))]
        [JsonPropertyName("decovered")]
        public long Recovered { get; set; }
    }
}
