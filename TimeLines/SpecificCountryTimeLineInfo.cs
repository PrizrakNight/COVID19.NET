using System;
using System.Text.Json.Serialization;

namespace COVID19.NET
{
    public struct SpecificCountryTimeLineInfo 
    {
        public CountryInfo Info { get; set; }
        public DateTime Date { get; set; }

        [JsonPropertyName("total_cases")]
        public long Cases { get; set; }
        [JsonPropertyName("total_recoveries")]
        public long Recoveries { get; set; }
        [JsonPropertyName("total_deaths")]
        public long Deaths { get; set; }
        [JsonPropertyName("new_daily_cases")]
        public long NewDailyCases { get; set; }
        [JsonPropertyName("new_daily_deaths")]
        public long NewDailyDeaths { get; set; }
    }
}