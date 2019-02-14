using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PoweredSoft.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace PoweredSoft.Data.MongoDB
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPoweredSoftMongoDBDataServices(this IServiceCollection services)
        {
            services.AddPoweredSoftDataServices();
            services.AddTransient<IAsyncQueryableHandlerService, AsyncQueryableHandlerService>();
            return services;
        }
    }
}
