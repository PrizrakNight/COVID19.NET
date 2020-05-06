using COVID19.NET.Converters;
using System;
using System.Text.Json.Serialization;

namespace COVID19.NET.CoronaVirusStats
{
    public struct CVSPageRecord
    {
        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("country_abbreviation")]
        public string CountryAbbreviation { get; set; }

        [JsonPropertyName("total_cases")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int TotalCases { get; set; }

        [JsonPropertyName("new_cases")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int NewCases { get; set; }

        [JsonPropertyName("total_deaths")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int TotalDeaths { get; set; }

        [JsonPropertyName("new_deaths")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int NewDeaths { get; set; }

        [JsonPropertyName("total_recovered")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int TotalRecovered { get; set; }

        [JsonPropertyName("active_cases")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int ActiveCases { get; set; }

        [JsonPropertyName("serious_critical")]
        [JsonConverter(typeof(StringToIntConverter))]
        public int SeriousCritical { get; set; }

        [JsonPropertyName("cases_per_mill_pop")]
        [JsonConverter(typeof(StringToDoubleConverter))]
        public double CasesPerMillPop { get; set; }

        [JsonPropertyName("flag")]
        public Uri Flag { get; set; }
    }
}
