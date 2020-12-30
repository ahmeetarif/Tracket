using FluentValidation;
using Microsoft.Extensions.Localization;
using Tracket.Common;
using Tracket.Infrastructure.Localization.Localizer;

namespace Tracket.Business.Extensions
{
    public static class RuleBuilderExtension
    {
        public static IRuleBuilder<T, string> Email<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithLocalizedMessage(Constants.LocalizeKeys.Email.Empty);
            return options;
        }

        public static IRuleBuilder<T, string> Username<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithLocalizedMessage(Constants.LocalizeKeys.Username.Empty);
            return options;
        }

        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithLocalizedMessage(Constants.LocalizeKeys.Password.Empty)
                .MinimumLength(6).WithMessage(Constants.LocalizeKeys.Password.Length)
                .Matches("[A-Z]").WithMessage(Constants.LocalizeKeys.Password.Uppercase)
                .Matches("[a-z]").WithMessage(Constants.LocalizeKeys.Password.Lowercase)
                .Matches("[0-9]").WithMessage(Constants.LocalizeKeys.Password.Number);
            return options;
        }

        public static IRuleBuilder<T, string> Fullname<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithLocalizedMessage(Constants.LocalizeKeys.Fullname.Empty)
                .MaximumLength(100).WithLocalizedMessage(Constants.LocalizeKeys.Fullname.Length);
            //.Must(IsValidName).WithMessage("Please enter valid Name!");
            return options;
        }

        #region Custom Rule Options

        private static IRuleBuilderOptions<T, string> WithLocalizedMessage<T>(this IRuleBuilderOptions<T, string> options, string key)
        {
            IStringLocalizer localizer = new JsonStringLocalizer();
            return options.Configure(x => x.CurrentValidator.Options.SetErrorMessage(localizer[key]));
        }

        #endregion
    }
}