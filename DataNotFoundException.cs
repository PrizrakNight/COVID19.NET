using System;

namespace COVID19.NET
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string key) :
            base($"Could not find data for the key '{key}', possibly the wrong key is specified" +
                $" or the site does not have data with the specified key")
        {
        }
    }
}
