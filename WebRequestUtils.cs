using System.IO;
using System.Net;

namespace COVID19.NET
{
    internal static class WebRequestUtils
    {
        internal static string GetJson(string url)
        {
            string json;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            request.ContentType = "application/json; charset=utf-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                json = reader.ReadToEnd();
            }

            return !string.IsNullOrEmpty(json) ? json : throw new NoDataException(url);
        }

        internal static string GetGlobalJson() => GetJson($"{TheVirusTrackerClient.APISource}?global=stats");
        internal static string GetCountriesJson() => GetJson($"{TheVirusTrackerClient.APISource}?countryTotals=ALL");
        internal static string GetTimeLines() => GetJson("https://thevirustracker.com/timeline/map-data.json");
        internal static string GetCountryJson(string countryCode) => GetJson($"{TheVirusTrackerClient.APISource}?countryTotal={countryCode}");
        internal static string GetCountryTimeLineJson(string countryCode) => GetJson($"{TheVirusTrackerClient.APISource}?countryTimeline={countryCode}");
    }
}
