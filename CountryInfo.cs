using System.Text.Json.Serialization;

namespace COVID19.NET
{
    public struct CountryInfo
    {
        [JsonPropertyName("title")]
        public string CountryName { get; set; }
        [JsonPropertyName("code")]
        public string CountryCode { get; set; }
        [JsonPropertyName("source")]
        public string SourceURL { get; set; }
    }
}
