using PoweredSoft.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace PoweredSoft.Data
{
    public class AsyncQueryableService : IAsyncQueryableService
    {
        public IEnumerable<IAsyncQueryableHandlerService> Handlers { get; }

        public AsyncQueryableService(IEnumerable<IAsyncQueryableHandlerService> handlers)
        {
            Handlers = handlers;
        }

        public Task<int> CountAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsyncQueryableHandlerOrThrow(queryable).CountAsync(queryable, cancellationToken);

        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsyncQueryableHandlerOrThrow(queryable).FirstOrDefaultAsync(queryable, cancellationToken);

        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsyncQueryableHandlerOrThrow(queryable).FirstOrDefaultAsync(queryable, predicate, cancellationToken);

        private IAsyncQueryableHandlerService GetAsyncQueryableHandlerOrThrow<T>(IQueryable<T> queryable)
        {
            var handler = this.GetAsyncQueryableHandler(queryable);
            if (handler == null)
                throw new NoAsyncQueryableHandlerServiceWasRegisteredForThisProviderException();

            return handler;
        }

        public IAsyncQueryableHandlerService GetAsyncQueryableHandler<T>(IQueryable<T> queryable)
        {
            var handler = Handlers.FirstOrDefault(t => t.CanHandle(queryable));
            return handler;
        }

        public Task<long> LongCountAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsyncQueryableHandlerOrThrow(queryable).LongCountAsync(queryable, cancellationToken);

        public Task<List<T>> ToListAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsyncQueryableHandlerOrThrow(queryable).ToListAsync(queryable, cancellationToken);

        public Task<bool> AnyAsync<T>(IQueryable<T> queryable, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsyncQueryableHandlerOrThrow(queryable).AnyAsync(queryable, predicate, cancellationToken);

        public Task<bool> AnyAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken))
            => GetAsyncQueryableHandlerOrThrow(queryable).AnyAsync(queryable, cancellationToken);
    }
}
