using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Tracket.Contracts.V1.Requests.Authentication;

namespace Tracket.Business.Validators.Authentication
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequestModel>
    {
        public RegisterRequestValidator()
        {

        }
    }
}
