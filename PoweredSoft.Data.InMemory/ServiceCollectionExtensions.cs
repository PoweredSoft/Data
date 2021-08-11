using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PoweredSoft.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Data.InMemory
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPoweredSoftInMemoryDataServices(this IServiceCollection services)
        {
            services.AddPoweredSoftDataServices();
            services.AddTransient<IAsyncQueryableHandlerService, InMemoryQueryableHandlerService>();
            return services;
        }
    }
}
