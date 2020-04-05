# COVID19.NET Library

![COVID19Image](https://2hfybu1lrdue3x9wnu1dvw7s-wpengine.netdna-ssl.com/wp-content/uploads/2020/03/covid-19-image.png)

With this simple library, you can easily and simply receive information from the website [Coronavirus Data API](https://thevirustracker.com/)

**Take care of yourself and your loved ones, do not get sick and follow safety measures so as not to get infected. May force come with us in these difficult times!**

### Examples of using

This method returns all data from [WebAPI](https://api.thevirustracker.com/free-api?countryTotals=ALL)

```csharp
var infos = await TheVirusTrackerClient.GetAllCountriesInfoAsync();
```

This method returns all the data of a specific country by its code.

```csharp
var info = await TheVirusTrackerClient.GetCountryInfoAsync(CountryCode.RU);
```

This method returns global data from around the world.

```csharp
var globalInfo = await TheVirusTrackerClient.GetGlobalInfoAsync();
```

This method returns all time lines of all countries.

```csharp
var timeLines = await TheVirusTrackerClient.GetFullTimeLineInfos();
```

This method returns the entire timeline of a specific country by its code.

```csharp
var timeLine = await TheVirusTrackerClient.GetCountryTimeLineAsync(CountryCode.RU);
```
