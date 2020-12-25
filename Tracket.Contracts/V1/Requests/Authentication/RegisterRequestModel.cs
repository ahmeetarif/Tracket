namespace Tracket.Contracts.V1.Requests.Authentication
{
    public class RegisterRequestModel
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}