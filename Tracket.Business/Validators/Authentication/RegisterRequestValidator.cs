﻿using FluentValidation;
using Tracket.Business.Extensions;
using Tracket.Contracts.V1.Requests.Authentication;

namespace Tracket.Business.Validators.Authentication
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequestModel>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email).Email();
            RuleFor(x => x.Fullname).Fullname();
            RuleFor(x => x.Password).Password();
        }
    }
}