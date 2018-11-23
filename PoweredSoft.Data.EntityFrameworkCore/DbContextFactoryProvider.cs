using PoweredSoft.Data.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace PoweredSoft.Data.EntityFrameworkCore
{
    public class DbContextFactoryProvider : IDbContextFactoryProvider
    {
        private readonly IServiceProvider serviceProvider;

        public DbContextFactoryProvider(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IDbContextFactory GetContextFactory(Type contextType)
        {
            var dbContext = this.serviceProvider.GetRequiredService(contextType) as DbContext;
            var dbContextFactory = new DbContextFactory(dbContext);
            return dbContextFactory;
        }
    }
}
