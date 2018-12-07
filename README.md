# IDbContextFactory

The goal of this project is to help, fill the gap of supporting multiple ORM's in DynamicQuery, and possibly more projects in the future.

One of the most obvious reason is to be able to execute async/await operations on the context without, the executing library to be dependant on the ORM Framework such as (EF Core, EF6).

## Getting Started

> Install nuget package to your awesome project.

Full Version                  | NuGet                                                                                                                                                                                                                                                                 |                                           NuGet Install
------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------:
PoweredSoft.Data.Core      | <a href="https://www.nuget.org/packages/PoweredSoft.Data.Core/" target="_blank">[![NuGet](https://img.shields.io/nuget/v/PoweredSoft.Data.Core.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/PoweredSoft.Data.Core/)</a>                |      ```PM> Install-Package PoweredSoft.Data.Core```
PoweredSoft.Data.EntityFrameworkCore | <a href="https://www.nuget.org/packages/PoweredSoft.Data.EntityFrameworkCore/" target="_blank">[![NuGet](https://img.shields.io/nuget/v/PoweredSoft.Data.EntityFrameworkCore.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/PoweredSoft.Data.EntityFrameworkCore/)</a> | ```PM> Install-Package PoweredSoft.Data.EntityFrameworkCore```


# In your application you may do the following

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services) 
    {
        services.AddPoweredSoftDataServices();
    }
}
```

> Then somewhere else.

```csharp
public class SomeClass
{
    private readonly IDbContextFactory contextFactory;
    public SomeClass(IDbContextFactoryProvider dbContextFactoryProvider)
    {
        contextFactory = dbContextFactoryProvider.GetContextFactory(typeof(YourFavoriteContext));
    }
}

```

## AsyncQueryableFactory

Also as the same kind of goal, will slowly add support for a non dependant to orm async method.

```csharp
public interface IAsyncQueryableFactory
{
    Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken));
    Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
    Task<List<T>> ToListAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken));
    Task<int> CountAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken));
    Task<long> LongCountAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken));
}
```