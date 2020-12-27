using Microsoft.Extensions.Localization;
using System;
using System.Threading.Tasks;
using Tracket.Business.Services.Abstract;
using Tracket.Contracts.V1.Requests.Authentication;
using Tracket.Contracts.V1.Responses.Authentication;
using Tracket.Core.Data.UnitOfWork;
using Tracket.Data;

namespace Tracket.Business.Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork<TracketDbContext> _unitOfWork;
        private readonly IStringLocalizer<AuthenticationService> _localizer;
        public AuthenticationService(IUnitOfWork<TracketDbContext> unitOfWork,
            IStringLocalizer<AuthenticationService> localizer)
        {
            this._unitOfWork = unitOfWork;
            this._localizer = localizer;
        }

        public async Task<AuthenticationResponseModel> RegisterAsync(RegisterRequestModel registerRequest)
        {
            throw new ArgumentNullException(_localizer["ProvideRequiredInformation"]);
        }
    }
}