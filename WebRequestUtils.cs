using System.IO;
using System.Net;

namespace COVID19.NET
{
    internal static partial class WebRequestUtils
    {
        internal static string GetJson(string url)
        {
            string json;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Proxy = null;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
            {
                json = reader.ReadToEnd();
            }

            return json;
        }
    }
}
