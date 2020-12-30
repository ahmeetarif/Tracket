using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tracket.Core.Data.UnitOfWork;
using Tracket.Entities.Entity;
using Tracket.Infrastructure.Identity.Managers.Abstract;
using Tracket.Infrastructure.Identity.Models.Requests.PermissionManager;
using Tracket.Infrastructure.Identity.Models.Responses.PermissionManager;

namespace Tracket.Infrastructure.Identity.Managers.Concrete
{
    public class PermissionManager<Context> : IPermissionManager
        where Context : DbContext
    {
        private readonly IUnitOfWork<Context> _unitOfWork;
        public PermissionManager(IUnitOfWork<Context> unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public PermissionManagerResponse AddPermission(AddPermissionRequestModel addPermissionRequest)
        {
            if (string.IsNullOrEmpty(addPermissionRequest.Title) || string.IsNullOrWhiteSpace(addPermissionRequest.Title))
            {
                return null;
            }

            Permission isPermissionExist = _unitOfWork.Repository<Permission>().Get(x => x.Title == addPermissionRequest.Title).FirstOrDefault();

            if (isPermissionExist != null)
            {
                return null;
            }

            Permission permission = new Permission
            {
                Title = addPermissionRequest.Title,
                Description = addPermissionRequest.Description,
                CreatedAt = DateTime.UtcNow
            };

            try
            {
                _unitOfWork.Repository<Permission>().Add(permission);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                _unitOfWork.Dispose();
            }

            return new PermissionManagerResponse
            {
                Message = "Permission Added"
            };
        }
    }
}