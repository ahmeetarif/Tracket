using Tracket.Core.Data.GenericRepository;
using Tracket.Data.Repositories.Abstract;
using Tracket.Entities.Entity;

namespace Tracket.Data.Repositories.Concrete
{
    public class UserDetailsRepository : GenericRepository<UserDetail, TracketDbContext>, IUserDetailsRepository
    {
        public UserDetailsRepository(TracketDbContext context)
            : base(context)
        {

        }
    }
}