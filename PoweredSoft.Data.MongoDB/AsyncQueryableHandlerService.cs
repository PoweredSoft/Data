using MongoDB.Driver.Linq;
using MongoDB.Driver;
using PoweredSoft.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoweredSoft.Data.MongoDB
{
    public class AsyncQueryableHandlerService : IAsyncQueryableHandlerService
    {
        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => ((IMongoQueryable<T>)queryable).FirstOrDefaultAsync(cancellationToken);
        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
            => ((IMongoQueryable<T>)queryable).FirstOrDefaultAsync(predicate, cancellationToken);
        public Task<List<T>> ToListAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => ((IMongoQueryable<T>)queryable).ToListAsync(cancellationToken);
        public Task<int> CountAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => ((IMongoQueryable<T>)queryable).CountAsync();
        public Task<long> LongCountAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => ((IMongoQueryable<T>)queryable).LongCountAsync();

        public bool CanHandle<T>(IQueryable<T> queryable) => queryable is IMongoQueryable<T>;

        public Task<bool> AnyAsync<T>(IQueryable<T> queryable, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
            => ((IMongoQueryable<T>)queryable).AnyAsync(predicate, cancellationToken);

        public Task<bool> AnyAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => ((IMongoQueryable<T>)queryable).AnyAsync(cancellationToken);
    }
}
