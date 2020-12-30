namespace Tracket.Infrastructure.Identity.Models.Requests.JwtTokenManager
{
    public partial class RefreshTokenRequestModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}