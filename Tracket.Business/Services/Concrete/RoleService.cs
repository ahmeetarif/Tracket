using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Tracket.Business.Services.Abstract;
using Tracket.Common;
using Tracket.Common.Exceptions;

namespace Tracket.Business.Services.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IStringLocalizer<RoleService> _localizer;
        private readonly ILogger<RoleService> _logger;
        public RoleService(RoleManager<IdentityRole> roleManager,
                IStringLocalizer<RoleService> localizer,
                ILogger<RoleService> logger)
        {
            this._roleManager = roleManager;
            this._localizer = localizer;
        }

        public async Task CreateRole(string roleName)
        {
            if (string.IsNullOrEmpty(roleName) || string.IsNullOrWhiteSpace(roleName))
            {
                throw new TracketBadRequestException(_localizer[Constants.LocalizedValueKeys.Messages.PleaseProvideRequiredInformationMessage]);
            }

            var isRoleExist = await _roleManager.FindByNameAsync(roleName);

            if (isRoleExist != null)
            {
            }

        }

    }
}