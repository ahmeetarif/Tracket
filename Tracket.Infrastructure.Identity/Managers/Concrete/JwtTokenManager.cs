using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tracket.Infrastructure.Identity.Managers.Abstract;
using Tracket.Infrastructure.Identity.Models.Requests.JwtTokenManager;
using Tracket.Infrastructure.Identity.Models.Responses.JwtTokenManager;
using Tracket.Infrastructure.Identity.Options;

namespace Tracket.Infrastructure.Identity.Managers.Concrete
{
    public class JwtTokenManager<User> : IJwtTokenManager<User>
        where User : IdentityUser
    {
        private readonly IdentityUserManager<User> _userManager;
        private readonly JwtOptions _jwtOptions;
        private readonly TokenValidationParameters _tokenValidationParameters;
        public JwtTokenManager(IdentityUserManager<User> userManager,
                JwtOptions jwtOptions,
                TokenValidationParameters tokenValidationParameters)
        {
            this._userManager = userManager;
            this._jwtOptions = jwtOptions;
            this._tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<JwtTokenManagerResponse> GenerateAccessTokenAsync(Claim[] userClaims, User user, string providerName = "ApplicationProvider", string refreshTokenName = "RefreshToken")
        {
            string accessToken = GenerateAccessToken(userClaims);
            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrWhiteSpace(accessToken))
            {
                return null;
            }

            string refreshToken = await GenerateRefreshToken(user, providerName, refreshTokenName);

            if (refreshToken == null)
            {
                return null;
            }

            return new JwtTokenManagerResponse
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        public async Task<JwtTokenManagerResponse> RefreshTokenAsync(RefreshTokenRequestModel refreshToken, Claim[] claims, string provider = "ApplicationProvider", string purpose = "RefreshToken")
        {
            if (refreshToken == null)
            {
                return null;
            }

            ClaimsPrincipal validatedToken = GetPrincipalFromToken(refreshToken.AccessToken);

            if (validatedToken == null)
            {
                return null;
            }

            string userEmail = validatedToken.Claims.FirstOrDefault(x => x.Type == "Email").Value;

            User userDetails = await _userManager.FindByEmailAsync(userEmail);

            if (userDetails == null)
            {
                return null;
            }

            bool validateRefreshToken = await _userManager.VerifyUserTokenAsync(userDetails, provider, purpose, refreshToken.RefreshToken);

            if (!validateRefreshToken)
            {
                return null;
            }

            string newRefreshToken = await GenerateRefreshToken(userDetails, provider, purpose);
            if (newRefreshToken == null)
            {
                return null;
            }

            string newAccessToken = GenerateAccessToken(claims);
            if (newAccessToken == null)
            {
                return null;
            }

            return new JwtTokenManagerResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        #region Private Functions

        private string GenerateAccessToken(Claim[] claims)
        {
            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = _jwtOptions.Issuer,
                Audience = _jwtOptions.Audience,
                Expires = DateTime.Now.Add(_jwtOptions.TokenLifetime),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

            string tokenAsString = jwtSecurityTokenHandler.WriteToken(token);

            return tokenAsString;
        }

        private async Task<string> GenerateRefreshToken(User user, string provider, string refreshTokenName)
        {
            string getAuthenticationToken = await _userManager.GetAuthenticationTokenAsync(user, provider, refreshTokenName);

            if (getAuthenticationToken != null)
            {
                IdentityResult removeAuthenticationTokenResult = await RemoveCurrentAuthenticationTokenAsync(user, provider, refreshTokenName);

                if (!removeAuthenticationTokenResult.Succeeded) return null;
            }

            string newToken = await _userManager.GenerateUserTokenAsync(user, provider, refreshTokenName);

            IdentityResult saveNewToken = await _userManager.SetAuthenticationTokenAsync(user, provider, refreshTokenName, newToken);

            if (!saveNewToken.Succeeded)
            {
                return null;
            }

            return newToken;
        }

        private async Task<IdentityResult> RemoveCurrentAuthenticationTokenAsync(User user, string provider, string authenticationTokenName)
        {
            try
            {
                await _userManager.RemoveAuthenticationTokenAsync(user, provider, authenticationTokenName);
                return IdentityResult.Success;
            }
            catch (Exception ex)
            {
                return IdentityResult.Failed();
            }
        }

        private ClaimsPrincipal GetPrincipalFromToken(string accessToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var tokenValidationParamters = _tokenValidationParameters.Clone();
                tokenValidationParamters.ValidateLifetime = false;

                ClaimsPrincipal principals = tokenHandler.ValidateToken(accessToken, tokenValidationParamters, out SecurityToken validatedToken);
                if (!IsJwtWithValidSecurityAlgorithm(validatedToken))
                {
                    return null;
                }

                return principals;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private bool IsJwtWithValidSecurityAlgorithm(SecurityToken validatedToken)
        {
            return (validatedToken is JwtSecurityToken jwtSecurityToken) &&
                   jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                       StringComparison.InvariantCultureIgnoreCase);
        }

        #endregion
    }
}