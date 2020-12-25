using Microsoft.EntityFrameworkCore;
using Tracket.Core.Data.GenericRepository;

namespace Tracket.Core.Data.UnitOfWork
{
    public interface IUnitOfWork<Context>
        where Context : DbContext
    {
        Context DBContext { get; }

        void Commit();

        void Dispose();

        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}