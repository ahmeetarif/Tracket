using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Linq;
using System.Threading.Tasks;
using Tracket.Business.Services.Abstract;
using Tracket.Common;
using Tracket.Common.Exceptions;
using Tracket.Contracts.V1.Requests.Authentication;
using Tracket.Contracts.V1.Responses.Authentication;
using Tracket.Core.Data.UnitOfWork;
using Tracket.Data;
using Tracket.Entities.Entity;
using Tracket.Infrastructure.Identity;

namespace Tracket.Business.Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork<TracketDbContext> _unitOfWork;
        private readonly IStringLocalizer<AuthenticationService> _localizer;
        private readonly IdentityUserManager<TracketUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AuthenticationService(IUnitOfWork<TracketDbContext> unitOfWork,
            IStringLocalizer<AuthenticationService> localizer,
            IdentityUserManager<TracketUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this._unitOfWork = unitOfWork;
            this._localizer = localizer;
            this._userManager = userManager;
            this._roleManager = roleManager;
        }

        public async Task<AuthenticationResponseModel> RegisterAsync(RegisterRequestModel registerRequest)
        {
            if (registerRequest == null)
            {
                throw new TracketBadRequestException(_localizer[Constants.LocalizeKeys.ProvideRequiredInformation]);
            }

            IdentityRole findRole = await _roleManager.FindByNameAsync(registerRequest.RoleName);

            if (findRole == null)
            {
                throw new TracketNotFoundException(_localizer[Constants.LocalizeKeys.RoleNotFound]);
            }

            return null;

        }
    }
}