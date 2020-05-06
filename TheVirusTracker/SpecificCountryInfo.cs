using System.Text.Json.Serialization;

namespace COVID19.NET.TheVirusTracker
{
    public class SpecificCountryInfo : COVID19Info
    {
        [JsonPropertyName("info")]
        public CountryInfo Info { get; set; }
        [JsonPropertyName("total_danger_rank")]
        public long DangerRank { get; set; }
    }
}
