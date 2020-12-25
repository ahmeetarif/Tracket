using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Tracket.Core.Data.GenericRepository
{
    public class GenericRepository<T, Context> : IGenericRepository<T>
        where T : class
        where Context : DbContext
    {
        private readonly Context _context;
        private readonly DbSet<T> _table;
        public GenericRepository(Context context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public void Add(T entity)
        {
            _table.Add(entity);
        }

        public void Delete(T entity)
        {
            T databaseData = _table.Find(entity);
            _table.Remove(databaseData);
        }

        public IEnumerable<T> Get()
        {
            return _table.ToList();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _table.Attach(entity);
        }
    }
}
