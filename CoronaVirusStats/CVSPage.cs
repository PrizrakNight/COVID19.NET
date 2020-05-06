using System.Text.Json.Serialization;

namespace COVID19.NET.CoronaVirusStats
{
    public class CVSPage
    {
        [JsonPropertyName("paginationMeta")]
        public CVSPageMeta Meta { get; set; }

        [JsonPropertyName("last_update")]
        public string LastUpdate { get; set; }

        [JsonPropertyName("rows")]
        public CVSPageRecord[] PageRecords { get; set; }
    }
}
