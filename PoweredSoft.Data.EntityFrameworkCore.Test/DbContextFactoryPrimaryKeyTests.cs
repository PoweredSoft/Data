using PoweredSoft.Test.Mock;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace PoweredSoft.Data.EntityFrameworkCore.Test
{
    public class DbContextFactoryPrimaryKeyTests
    {
        private readonly ITestOutputHelper output;

        public DbContextFactoryPrimaryKeyTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Simple()
        {
            MockContextFactory.SeedAndTestContextFor("DbContextFactoryPrimaryKeyTests_Simple", TestSeeders.SimpleSeedScenario, ctx =>
            {
                var sw = new Stopwatch();
                sw.Start();
                var factory = new DbContextFactory(ctx);
                var keys = factory.GetKeyProperties(typeof(Order));
                Assert.Single<PropertyInfo>(keys, t => t.Name == "Id");
                sw.Stop();
                output.WriteLine($"Stop Watch of success took: {sw.Elapsed}");
            });
        }
    }
}
