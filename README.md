# COVID19.NET Library

![COVID19Image](https://novostivoronezha.ru/wp-content/uploads/2020/04/2020-04-04_12-19-14600-598x353.jpg)

With this simple library, you can easily and simply receive information from the website [Coronavirus Data API](https://thevirustracker.com/)

**Take care of yourself and your loved ones, do not get sick and follow safety measures so as not to get infected. May force come with us in these difficult times!**

I hope this library will help you in your research, good luck to everyone, thank you for deciding to try this tool!

### Examples of using

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
### Exceptions

`DataNotFoundException` - As a rule, this exception is thrown if the country code was entered incorrectly.
`NoDataException` - This exception is thrown if the site returned empty data.
This may be the case when the site is on technical servicing, or for some reason has stopped returning the necessary data.
In this case, it is better to visit the [site](https://thevirustracker.com/api) itself and find out the reason for the lack of data.