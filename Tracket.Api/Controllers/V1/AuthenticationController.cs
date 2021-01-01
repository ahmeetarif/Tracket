using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tracket.Business.Services.Abstract;
using Tracket.Contracts.V1;
using Tracket.Contracts.V1.Requests.Authentication;

namespace Tracket.Api.Controllers.V1
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [Route(ApiRoutes.Authentication.Register)]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequestModel registerModel)
        {
            await _authenticationService.RegisterAsync(registerModel);
            return Ok();
        }
    }
}