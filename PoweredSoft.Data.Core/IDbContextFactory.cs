using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PoweredSoft.Data.Core
{
    public interface IDbContextFactory
    {
        IQueryable<T> GetQueryable<T>()
            where T : class;

        IQueryable GetQueryable(Type type);
        void Add(object entity);
        void Remove(object entity);
        int SaveChanges();
        Task<int> SaveChangesAsync();

        Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken);
        Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken);
        Task<List<T>> ToListAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken);
    }
}
