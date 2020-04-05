# COVID19.NET Library

![COVID19Image](https://2hfybu1lrdue3x9wnu1dvw7s-wpengine.netdna-ssl.com/wp-content/uploads/2020/03/covid-19-image.png)

With this simple library, you can easily and simply receive information from the website [Coronavirus Data API]  (https://thevirustracker.com/)

**Take care of yourself and your loved ones, do not get sick and follow safety measures so as not to get infected. May force come with us in these difficult times!**

### Examples of using

This method returns all data from [WebAPI](https://api.thevirustracker.com/free-api?countryTotals=ALL)

```csharp var infos = await TheVirusTrackerClient.GetAllCountriesInfoAsync(); ```
