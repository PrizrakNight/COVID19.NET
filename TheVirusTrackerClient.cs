using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace COVID19.NET
{
    /// <summary>Provides easy access to site data "https://thevirustracker.com/api".</summary>
    public static class TheVirusTrackerClient
    {
        /// <summary>URL where most requests are sent to receive data.</summary>
        public const string APISource = "https://api.thevirustracker.com/free-api";

        /// <summary>Return all of the current accumulated stats from Coronavirus Tracker for all indexed Country's.</summary>
        public static Task<ReadOnlyCollection<SpecificCountryInfo>> GetAllCountriesInfoAsync() => Task.Factory.StartNew(() =>
        {
            List<SpecificCountryInfo> infos = new List<SpecificCountryInfo>();

            using (JsonDocument jsonDocument = JsonDocument.Parse(WebRequestUtils.GetJson($"{APISource}?countryTotals=ALL")))
            {
                foreach (JsonProperty property in jsonDocument.RootElement
                .GetProperty("countryitems")
                .EnumerateArray()
                .First()
                .EnumerateObject())
                {
                    if (!property.Name.Equals("stat"))
                    {
                        string json = property.Value.ToString();

                        SpecificCountryInfo countryInfo = JsonSerializer.Deserialize<SpecificCountryInfo>(json);
                        countryInfo.Info = JsonSerializer.Deserialize<CountryInfo>(json);

                        infos.Add(countryInfo);
                    }
                }
            }

            return new ReadOnlyCollection<SpecificCountryInfo>(infos);
        });

        /// <summary>Return all of the current accumulated stats from Coronavirus Tracker for a specified Country</summary>
        /// <param name="countryCode">Code of the country</param>
        public static Task<SpecificCountryInfo> GetCountryInfoAsync(CountryCode countryCode) => Task.Factory.StartNew(() =>
        {
            using (JsonDocument jsonDocument = JsonDocument.Parse(WebRequestUtils.GetJson($"{APISource}?countryTotal={countryCode.ToString()}")))
            {
                foreach (JsonElement element in jsonDocument.RootElement.GetProperty("countrydata").EnumerateArray())
                    return JsonSerializer.Deserialize<SpecificCountryInfo>(element.ToString());
            }

            return new SpecificCountryInfo();
        });

        /// <summary>receive all of the current globally accumulated stats from Coronavirus Tracker.</summary>
        public static Task<GlobalCOVID19Info> GetGlobalInfoAsync() => Task.Factory.StartNew(() =>
        {
            using (JsonDocument jsonDocument = JsonDocument.Parse(WebRequestUtils.GetJson($"{APISource}?global=stats")))
            {
                foreach (JsonElement element in jsonDocument.RootElement.GetProperty("results").EnumerateArray())
                    return JsonSerializer.Deserialize<GlobalCOVID19Info>(element.ToString());
            }

            return new GlobalCOVID19Info();
        });

        /// <summary>Return all TimeLine of the data for a specific Country from Coronavirus Tracker.</summary>
        /// <param name="countryCode">Code of the country</param>
        public static Task<ReadOnlyCollection<SpecificCountryTimeLineInfo>> GetCountryTimeLineAsync(CountryCode countryCode) => Task.Factory.StartNew(() =>
        {
            List<SpecificCountryTimeLineInfo> timeLineInfos = new List<SpecificCountryTimeLineInfo>();

            using (JsonDocument jsonDocument = JsonDocument.Parse(WebRequestUtils.GetJson($"{APISource}?countryTimeline={countryCode.ToString()}")))
            {
                var infoJson = jsonDocument.RootElement
                .GetProperty("countrytimelinedata")
                .EnumerateArray()
                .First()
                .EnumerateObject()
                .First()
                .Value.ToString();

                var countryInfo = JsonSerializer.Deserialize<CountryInfo>(infoJson);

                foreach (JsonProperty property in jsonDocument.RootElement.GetProperty("timelineitems").EnumerateArray().First().EnumerateObject())
                {
                    if (!property.Name.Equals("stat"))
                    {
                        SpecificCountryTimeLineInfo timeLineInfo = JsonSerializer.Deserialize<SpecificCountryTimeLineInfo>(property.Value.ToString());

                        timeLineInfo.Info = countryInfo;
                        timeLineInfo.Date = ParseDate(property.Name);

                        timeLineInfos.Add(timeLineInfo);
                    }
                }
            }

            return new ReadOnlyCollection<SpecificCountryTimeLineInfo>(timeLineInfos);
        });

        /// <summary>Return all of the timeline data from the Coronavirus Tracker.</summary>
        public static Task<ReadOnlyCollection<CountryTimeLineInfo>> GetFullTimeLineInfos() => Task.Factory.StartNew(() =>
        {
            List<CountryTimeLineInfo> timeLineInfos;

            using (JsonDocument jsonDocument = JsonDocument.Parse(WebRequestUtils.GetJson("https://thevirustracker.com/timeline/map-data.json")))
            {
                string dataJson = jsonDocument.RootElement.GetProperty("data").ToString();

                timeLineInfos = JsonSerializer.Deserialize<List<CountryTimeLineInfo>>(dataJson);
            }

            return new ReadOnlyCollection<CountryTimeLineInfo>(timeLineInfos);
        });

        private static DateTime ParseDate(string dateString)
        {
            string[] dateInfo = dateString.Split('/');

            return new DateTime(2000 + int.Parse(dateInfo[2]), int.Parse(dateInfo[0]), int.Parse(dateInfo[1]));
        }
    }
}
