# IDbContextFactory

The goal of this project is to help, fill the gap of supporting multiple ORM's in DynamicQuery, and possibly more projects in the future.

One of the most obvious reasy is to be able to execute async/await operations on the context without, the executing library to be dependant on the ORM Framework such as (EF Core, EF6).

## Getting Started

> Install nuget package to your awesome project.

Full Version                  | NuGet                                                                                                                                                                                                                                                                 |                                           NuGet Install
------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------:
PoweredSoft.Data.Core      | <a href="https://www.nuget.org/packages/PoweredSoft.Data.Core/" target="_blank">[![NuGet](https://img.shields.io/nuget/v/PoweredSoft.Data.Core.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/PoweredSoft.Data.Core/)</a>                |      ```PM> Install-Package PoweredSoft.Data.Core```
PoweredSoft.Data.EntityFrameworkCore | <a href="https://www.nuget.org/packages/PoweredSoft.Data.EntityFrameworkCore/" target="_blank">[![NuGet](https://img.shields.io/nuget/v/PoweredSoft.Data.EntityFrameworkCore.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/PoweredSoft.Data.EntityFrameworkCore/)</a> | ```PM> Install-Package PoweredSoft.Data.EntityFrameworkCore```