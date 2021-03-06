﻿using System.Text.Json.Serialization;

namespace COVID19.NET.TheVirusTracker
{
    public class GlobalCOVID19Info : COVID19Info
    {
        [JsonPropertyName("total_affected_countries")]
        public int AffectedCountries { get; set; }
    }
}
