using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;
using Tracket.Business.Services.Abstract;
using Tracket.Contracts.V1;

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
        [HttpGet]
        public async Task<IActionResult> Register()
        {
            CultureInfo.CurrentCulture = new CultureInfo("tr-TR");
            await _authenticationService.RegisterAsync(null);
            return Ok();
        }
    }
}