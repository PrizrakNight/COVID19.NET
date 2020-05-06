using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Threading.Tasks;

namespace COVID19.NET.CoronaVirusStats
{
    /// <summary>Provides easy access to "https://corona-virus-stats.herokuapp.com/api/v1/cases/countries-search" site data</summary>
    public static class CVSClient
    {
        /// <summary>URL where most requests are sent to receive data.</summary>
        public const string APISource = "https://corona-virus-stats.herokuapp.com/api/v1/cases/countries-search";

        /// <summary>Asynchronously retrieves a COVID-19 data page</summary>
        /// <param name="pageNumber">The page number to retrieve</param>
        /// <param name="elements">The number of elements that should be on this page. The maximum value that the site gives is 200 elements</param>
        public static Task<CVSPage> GetPageAsync(int pageNumber = 1, int elements = 12) => Task.Factory.StartNew(() =>
        {
            string json = GetDataJson(WebRequestUtils.GetJson($"{APISource}?page={pageNumber}&limit={elements}"));

            return JsonSerializer.Deserialize<CVSPage>(json);
        });

        /// <summary>Asynchronously returns all available pages with COVID-19 data.
        /// <para>At the moment it is 2 pages.</para></summary>
        public static Task<ReadOnlyCollection<CVSPage>> GetAllPagesAsync() => Task.Factory.StartNew(() =>
        {
            var result = new List<CVSPage>();
            var pageA = GetPageAsync(1, 200);
            var pageB = GetPageAsync(2, 200);

            Task.WaitAll(pageA, pageB);

            result.Add(pageA.Result);
            result.Add(pageB.Result);

            return new ReadOnlyCollection<CVSPage>(result);
        });

        private static string GetDataJson(string rawJson)
        {
            using (JsonDocument document = JsonDocument.Parse(rawJson))
            {
                return document.RootElement.GetProperty("data").ToString();
            }
        }
    }
}
