﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MongoDB.Driver;
using PoweredSoft.Test.Mock;
using PoweredSoft.Data.Core;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PoweredSoft.Data.EntityFrameworkCore.Test
{
    public class CohabitTest
    {
        [Fact]
        public void TestCohabitation()
        {
            var mongoHandler = new PoweredSoft.Data.MongoDB.AsyncQueryableHandlerService();
            var efCoreHandler = new PoweredSoft.Data.EntityFrameworkCore.AsyncQueryableHandlerService();
            var service = new PoweredSoft.Data.AsyncQueryableService(new IAsyncQueryableHandlerService[] { mongoHandler, efCoreHandler });

            var mongoClient = new MongoClient();
            var db = mongoClient.GetDatabase("acme");
            var mongoOrders = db.GetCollection<Order>("orders").AsQueryable();

            var options = new DbContextOptionsBuilder<MockContext>().UseInMemoryDatabase(databaseName: "CohabitTest_TestCohabitation").Options;
            var context = new MockContext(options);
            var set = context.Set<Order>();
            var efCoreOrders = set.AsQueryable();

            var shouldBeMongoHandler = service.GetAsyncQueryableHandler(mongoOrders);
            Assert.Equal(mongoHandler, shouldBeMongoHandler);

            var shouldBeEfCoreHandler = service.GetAsyncQueryableHandler(efCoreOrders);
            Assert.Equal(efCoreHandler, shouldBeEfCoreHandler);
        }
    }
}