# COVID19.NET Library

![COVID19Image](https://novostivoronezha.ru/wp-content/uploads/2020/04/2020-04-04_12-19-14600-598x353.jpg)

This simple library should help you research COVID-19.
It provides basic capabilities and clients for COVID-19 trackers.

**Take care of yourself and your loved ones, do not get sick and follow safety measures so as not to get infected. May force come with us in these difficult times!**

I hope this library will help you, good luck to everyone, thank you for deciding to try this tool!

------------



### Available types of client trackers for statistics

`COVID19.NET.TheVirusTracker.TheVirusTrackerClient`  - Provides easy access to site data [Coronavirus Data API](https://thevirustracker.com/ "Coronavirus Data API").

Features of this client:
1. There is detailed information.
	1. Global.
	2. Country-specific.

2. There are timelines for COVID-19.
	1. Global timeline.
	2. Country-specific timeline.

`COVID19.NET.CoronaVirusStats.CVSClient` - Provides easy access to WebAPI [corona-virus-stats.herokuapp.com](https://corona-virus-stats.herokuapp.com/api/v1/cases/countries-search "corona-virus-stats.herokuapp.com") data.

Features of this client:

1.  Brief information about country infections on the page of interest.
2. There is a link to the image of the flag of the country.

------------


### Examples of using

#####An example of working with TheVirusTrackerClient
This method will return data from all countries.

```csharp
var infos = await TheVirusTrackerClient.GetAllCountriesInfoAsync();
```

These methods returns all the data of a specific country by its code.

```csharp
var info = await TheVirusTrackerClient.GetCountryInfoAsync(CountryCode.RU);
var infoFromString = await TheVirusTrackerClient.GetCountryInfoAsync("RU");
```

This method returns global data from around the world.

```csharp
var globalInfo = await TheVirusTrackerClient.GetGlobalInfoAsync();
```

This method returns all time lines of all countries.

```csharp
var timeLines = await TheVirusTrackerClient.GetFullTimeLineInfosAsync();
```

These methods returns the entire timeline of a specific country by its code.

```csharp
var timeLine = await TheVirusTrackerClient.GetCountryTimeLineAsync(CountryCode.RU);
var timeLineFromString = await TheVirusTrackerClient.GetCountryTimeLineAsync("RU");
```

#####An example of working with CVSClient
This method asynchronously returns the specified page with the specified number of elements on it.

*The page number and the number of page elements are optional.
The default values are:*

*pageNumber: 1
elements: 12*

```csharp
var pageNumber2 = await CVSClient.GetPageAsync(pageNumber: 2, elements: 20);
```

This method returns all available pages from the site.
Currently, only 2 pages are available on the site.
```csharp
var allPages = await CVSClient.GetAllPagesAsync();
```
### Exceptions

`DataNotFoundException` - As a rule, this exception is thrown if the country code was entered incorrectly.

`NoDataException` - This exception is thrown if the site returned empty data.
This may be the case when the site is on technical servicing, or for some reason has stopped returning the necessary data.
In this case, it is better to visit the [site](https://thevirustracker.com/api) itself and find out the reason for the lack of data.