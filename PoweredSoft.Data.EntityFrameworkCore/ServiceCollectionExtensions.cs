using Microsoft.Extensions.DependencyInjection;
using PoweredSoft.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Data.EntityFrameworkCore
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPoweredSoftDataServices(this IServiceCollection services)
        {
            services.AddTransient<IDbContextFactoryProvider, DbContextFactoryProvider>();
            return services;
        }
    }
}
