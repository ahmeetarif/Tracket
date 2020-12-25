using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Tracket.Core.Data.GenericRepository
{
    public interface IGenericRepository<T>
        where T : class
    {
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}