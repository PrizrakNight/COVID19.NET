using System.Text.Json.Serialization;

namespace COVID19.NET
{
    public class COVID19Info
    {
        [JsonPropertyName("total_cases")]
        public long Cases { get; set; }
        [JsonPropertyName("total_recovered")]
        public long Recovered { get; set; }
        [JsonPropertyName("total_unresolved")]
        public long Unresolved { get; set; }
        [JsonPropertyName("total_deaths")]
        public long Deaths { get; set; }
        [JsonPropertyName("total_active_cases")]
        public long ActiveCases { get; set; }
        [JsonPropertyName("total_serious_cases")]
        public long SeriousCases { get; set; }
        [JsonPropertyName("total_new_cases_today")]
        public long NewCasesToday { get; set; }
    }
}
