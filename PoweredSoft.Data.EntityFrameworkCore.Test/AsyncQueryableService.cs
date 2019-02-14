using PoweredSoft.Test.Mock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PoweredSoft.Data.EntityFrameworkCore.Test
{
    public class AsyncQueryableServiceTests
    {
        [Fact]
        public void TestCanHandle()
        {
            MockContextFactory.SeedAndTestContextFor("AsyncQueryableServiceTests_TestCanHandle", TestSeeders.SimpleSeedScenario, ctx =>
            {
                var test = new AsyncQueryableHandlerService();
                IQueryable<Order> query = ctx.Orders;
                var query2 = query.GroupBy(t => t.Customer);
                var query3 = query.Where(t => t.Customer.LastName == "David");

                Assert.True(test.CanHandle(query));
                Assert.True(test.CanHandle(query2));
                Assert.True(test.CanHandle(query3));
            });        
        }

        [Fact]
        public void TestFirstOrDefault()
        {
            MockContextFactory.SeedAndTestContextFor("AsyncQueryableServiceTests_TestCanHandle", TestSeeders.SimpleSeedScenario, async ctx =>
            {
                var handler = new AsyncQueryableHandlerService();
                var service = new AsyncQueryableService(new[] { handler });
                var first = await service.FirstOrDefaultAsync(ctx.Orders);
            });
        }
    }
}
