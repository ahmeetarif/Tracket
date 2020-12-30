using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading.Tasks;
using Tracket.Infrastructure.Identity.Models.Requests.JwtTokenManager;
using Tracket.Infrastructure.Identity.Models.Responses.JwtTokenManager;

namespace Tracket.Infrastructure.Identity.Managers.Abstract
{
    public interface IJwtTokenManager<User>
        where User : IdentityUser
    {
        Task<JwtTokenManagerResponse> RefreshTokenAsync(RefreshTokenRequestModel refreshToken, Claim[] claims, string provider = "ApplicationProvider", string purpose = "RefreshToken");

        Task<JwtTokenManagerResponse> GenerateAccessTokenAsync(Claim[] userClaims, User user, string providerName = "ApplicationProvider", string refreshTokenName = "RefreshToken");
    }
}