using Microsoft.EntityFrameworkCore;
using PoweredSoft.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PoweredSoft.Data.EntityFrameworkCore
{
    public class AsyncQueryableFactory : IAsyncQueryableFactory
    {
        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => queryable.FirstOrDefaultAsync(cancellationToken);
        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken)) 
            => queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        public Task<List<T>> ToListAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken)) 
            => queryable.ToListAsync(cancellationToken);
        public Task<int> CountAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => queryable.CountAsync();
        public Task<long> LongCountAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => queryable.LongCountAsync();
    }
}
