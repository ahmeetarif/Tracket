using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Tracket.Core.Data.GenericRepository;
namespace Tracket.Core.Data.UnitOfWork
{
    public class UnitOfWork<Context> : IUnitOfWork<Context>
        where Context : DbContext
    {
        public UnitOfWork(Context context)
        {
            DBContext = context;
        }

        public Context DBContext { get; }

        public void Commit()
        {
            DBContext.SaveChanges();
        }

        public void Dispose()
        {
            DBContext.Dispose();
        }

        private Dictionary<string, dynamic> _repositories;

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, dynamic>();

            var type = typeof(TEntity).Name;

            if (_repositories.ContainsKey(type))
                return (IGenericRepository<TEntity>)_repositories[type];

            var repositoryType = typeof(GenericRepository<TEntity, Context>);

            _repositories.Add(type, Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), this));

            return _repositories[type];
        }
    }
}