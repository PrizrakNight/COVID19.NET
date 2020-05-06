using System.Text.Json.Serialization;

namespace COVID19.NET.CoronaVirusStats
{
    public struct CVSPageMeta
    {
        [JsonPropertyName("currentPage")]
        public int CurrentPage { get; set; }

        [JsonPropertyName("currentPageSize")]
        public int CurrentPageSize { get; set; }

        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("totalRecords")]
        public int TotalRecords { get; set; }
    }
}
