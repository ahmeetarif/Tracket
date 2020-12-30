using Tracket.Core.Data.GenericRepository;
using Tracket.Data.Repositories.Abstract;
using Tracket.Entities.Entity;

namespace Tracket.Data.Repositories.Concrete
{
    public class PermissionRepository : GenericRepository<Permission, TracketDbContext>, IPermissionRepository
    {
        public PermissionRepository(TracketDbContext context)
            : base(context)
        {

        }
    }
}