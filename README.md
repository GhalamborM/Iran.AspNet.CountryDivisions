
# Iran.AspNet.CountryDivisions

## Development 



[![Build status](https://img.shields.io/appveyor/ci/keyone2693/iran-aspnet-countrydivisions.svg)](https://ci.appveyor.com/project/keyone2693/imageresizer-aspnetcore)
[![NuGet](https://img.shields.io/nuget/v/Iran.AspNet.CountryDivisions.svg)](https://www.nuget.org/packages/Iran.AspNet.CountryDivisions/)
[![GitHub issues](https://img.shields.io/github/issues/keyone2693/Iran.AspNet.CountryDivisions.svg?maxAge=25920?style=plastic)](https://github.com/keyone2693/Iran.AspNet.CountryDivisions/issues)
[![GitHub stars](https://img.shields.io/github/stars/keyone2693/Iran.AspNet.CountryDivisions.svg?maxAge=25920?style=plastic)](https://github.com/keyone2693/Iran.AspNet.CountryDivisions/stargazers)
[![GitHub license](https://img.shields.io/github/license/keyone2693/Iran.AspNet.CountryDivisions.svg?maxAge=25920?style=plastic)](https://github.com/keyone2693/Iran.AspNet.CountryDivisions/blob/master/LICENSE)


### Json Files: [files](https://github.com/keyone2693/Iran.AspNet.CountryDivisions/tree/master/Iran.AspNet.CountryDivisions/Data)


#### Current version: 1.1.x [Stable]
In this version:
you can get all provinces, cities, districts, cities, towns and villages
or search for them

and there is no relation between tables 
i think we won't need this future
if you think otherwise tell me :)

## Overview

##
.net standard 2.0

## Easy to install
Use the library as dll, reference from [nuget](https://www.nuget.org/packages/Iran.AspNet.CountryDivisions/)
or use this in package manager console
```c#
Install-Package Iran.AspNet.CountryDivisions
```



# Wiki

you only need to add two things

first:
add this line of code to your Startup.cs


```c#
public void ConfigureServices(IServiceCollection services)
{
  //...
  services.AddIranCountryDivisions();
  //...
}
```

or :

```c#
public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
  //...
  services.AddScoped<IIranCountryDivisions, IranCountryDivisions>();
  //...
}
```
or :

```c#
  //...
  IIranCountryDivisions _iranCountryDivisions = new IranCountryDivisions();
  //...
```

then you can uus it like this :

```c#
  //...
  var allOstans = await _iranCountryDivisions.GetOstansAsync(null, null);
  var ostansWithSearchAndOrderByAndCount = await _iranCountryDivisions.GetOstansAsync(p => p.Name.Contains(nameSearch), o=>o.OrderBy(p=>p.Name)) , 10);
  
  
  var allOstans = await _iranCountryDivisions.GetOstansAsync(null, null);
  var ostansWithSearchAndOrderByAndCount = await _iranCountryDivisions.GetAbadisAsync(p => p.ShahrestanId == shahrId &&  p.Name.Contains(nameSearch));
  
  //...
```
same for others


## Special thanks

[Ahmad Azizi](https://github.com/ahmadazizi) and his [database](https://github.com/ahmadazizi/iran-cities/)

