﻿using Tracket.Core.Data.GenericRepository;
using Tracket.Data.Repositories.Abstract;
using Tracket.Entities.Entity;

namespace Tracket.Data.Repositories.Concrete
{
    public class UserPermissionRepository : GenericRepository<UserPermission, TracketDbContext>, IUserPermissionRepository
    {
        public UserPermissionRepository(TracketDbContext context)
            : base(context)
        {

        }
    }
}