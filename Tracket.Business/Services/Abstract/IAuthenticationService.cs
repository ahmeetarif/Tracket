using System.Threading.Tasks;
using Tracket.Contracts.V1.Requests.Authentication;
using Tracket.Contracts.V1.Responses.Authentication;

namespace Tracket.Business.Services.Abstract
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponseModel> RegisterAsync(RegisterRequestModel registerRequest);
    }
}