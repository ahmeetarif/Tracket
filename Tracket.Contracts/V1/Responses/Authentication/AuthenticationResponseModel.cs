﻿namespace Tracket.Contracts.V1.Responses.Authentication
{
    public class AuthenticationResponseModel
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }
    }
}