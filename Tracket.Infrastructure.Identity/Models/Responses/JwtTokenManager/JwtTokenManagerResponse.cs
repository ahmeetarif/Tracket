namespace Tracket.Infrastructure.Identity.Models.Responses.JwtTokenManager
{
    public class JwtTokenManagerResponse
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }
    }
}