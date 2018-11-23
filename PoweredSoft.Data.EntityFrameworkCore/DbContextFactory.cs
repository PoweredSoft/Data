using Microsoft.EntityFrameworkCore;
using PoweredSoft.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace PoweredSoft.Data.EntityFrameworkCore
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly DbContext _context;
        private MethodInfo _setGenericMethod = null;

        public DbContextFactory(DbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add(object entity) => _context.Add(entity);

  

        public IQueryable<T> GetQueryable<T>() where T : class => _context.Set<T>();

        public IQueryable GetQueryable(Type type)
        {
            if (_setGenericMethod == null)
                _setGenericMethod = typeof(DbContextFactory).GetMethods().FirstOrDefault(t => t.Name == nameof(GetQueryable) && t.ContainsGenericParameters);

            var gm = _setGenericMethod.MakeGenericMethod(type);
            var ret = (IQueryable)gm.Invoke(this, new object[] { });
            return ret;
        }

        public void Remove(object entity)
        {
            _context.Remove(entity);
        }

        public int SaveChanges() => _context.SaveChanges();
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken)) => queryable.FirstOrDefaultAsync(cancellationToken);
        public Task<T> FirstOrDefaultAsync<T>(IQueryable<T> queryable, Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken)) => queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        public Task<List<T>> ToListAsync<T>(IQueryable<T> queryable, CancellationToken cancellationToken = default(CancellationToken)) => queryable.ToListAsync(cancellationToken);
    }
}
