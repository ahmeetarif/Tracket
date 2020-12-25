using System;
using System.Threading.Tasks;
using Tracket.Business.Services.Abstract;
using Tracket.Contracts.V1.Requests.Authentication;
using Tracket.Core.Data.UnitOfWork;
using Tracket.Data;

namespace Tracket.Business.Services.Concrete
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork<TracketDbContext> _unitOfWork;
        public AuthenticationService(IUnitOfWork<TracketDbContext> unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}