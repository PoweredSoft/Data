﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PoweredSoft.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PoweredSoft.Data.EntityFrameworkCore
{
    public class AsyncQueryableHandlerService : IAsyncQueryableHandlerService
    {
        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default)
            => queryable.FirstOrDefaultAsync(cancellationToken);
        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default) 
            => queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        public Task<List<T>> ToListAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default) 
            => queryable.ToListAsync(cancellationToken);
        public Task<int> CountAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default)
            => queryable.CountAsync();
        public Task<long> LongCountAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default)
            => queryable.LongCountAsync();

        public bool CanHandle<T>(IQueryable<T> queryable) => queryable.Provider is IAsyncQueryProvider;

        public Task<bool> AnyAsync<T>(IQueryable<T> queryable, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default)
            => queryable.AnyAsync(predicate, cancellationToken);

        public Task<bool> AnyAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default)
            => queryable.AnyAsync(cancellationToken);
    }
}
