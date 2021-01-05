using System.Collections.Generic;
using System.Threading.Tasks;
using Tracket.Contracts.V1.Responses.RoleManager;
using Tracket.Dto.Models;

namespace Tracket.Business.Services.Abstract
{
    public interface IRoleService
    {
        Task<RoleManagerResponseModel> CreateRoleAsync(string roleName);
        IEnumerable<RoleDto> GetRoles();
        Task<RoleDto> GetRoleAsync(string roleName);
        Task<RoleManagerResponseModel> DeleteRoleAsync(string roleName);
    }
}