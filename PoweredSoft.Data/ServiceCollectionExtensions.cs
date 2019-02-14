using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PoweredSoft.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPoweredSoftDataServices(this IServiceCollection services)
        {
            services.TryAddTransient<IAsyncQueryableService, AsyncQueryableService>();
            return services;
        }
    }
}
