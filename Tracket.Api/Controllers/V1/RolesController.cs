using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tracket.Business.Services.Abstract;
using Tracket.Contracts.V1;

namespace Tracket.Api.Controllers.V1
{
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            this._roleService = roleService;
        }

        [Route(ApiRoutes.Roles.CreateRole)]
        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] string roleName)
        {
            var response = await _roleService.CreateRoleAsync(roleName);
            return Ok(response);
        }

        [Route(ApiRoutes.Roles.GetRoles)]
        [HttpGet]
        public IActionResult GetRoles()
        {
            var response = _roleService.GetRoles();
            return Ok(response);
        }

        [Route(ApiRoutes.Roles.GetRole)]
        [HttpGet]
        public async Task<IActionResult> GetRole(string roleName)
        {
            var response = await _roleService.GetRoleAsync(roleName);
            return Ok(response);
        }

        [Route(ApiRoutes.Roles.Delete)]
        [HttpPost]
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var response = await _roleService.DeleteRoleAsync(roleName);
            return Ok(response);
        }
    }
}