namespace COVID19.NET.TheVirusTracker
{
    internal static partial class TheVirusTrackerUtils
    {
        internal static string GetGlobalJson() => WebRequestUtils.GetJson($"{TheVirusTrackerClient.APISource}?global=stats");
        internal static string GetCountriesJson() => WebRequestUtils.GetJson($"{TheVirusTrackerClient.APISource}?countryTotals=ALL");
        internal static string GetTimeLines() => WebRequestUtils.GetJson("https://thevirustracker.com/timeline/map-data.json");
        internal static string GetCountryJson(string countryCode) => WebRequestUtils.GetJson($"{TheVirusTrackerClient.APISource}?countryTotal={countryCode}");
        internal static string GetCountryTimeLineJson(string countryCode) => WebRequestUtils.GetJson($"{TheVirusTrackerClient.APISource}?countryTimeline={countryCode}");
    }
}
