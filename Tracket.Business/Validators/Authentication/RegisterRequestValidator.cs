using FluentValidation;
using Tracket.Business.Extensions;
using Tracket.Contracts.V1.Requests.Authentication;

namespace Tracket.Business.Validators.Authentication
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequestModel>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Email).Email();
        }
    }
}