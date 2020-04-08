using System;

namespace COVID19.NET
{
    public class NoDataException : Exception
    {
        public NoDataException(string request) :
            base($"The site 'https://thevirustracker.com/' did not return any data for the query '{request}'," +
                $" the request may be incorrect or the site for some reason does not return data.")
        {
        }
    }
}
