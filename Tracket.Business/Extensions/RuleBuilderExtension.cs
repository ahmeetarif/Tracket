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
                .NotEmpty().WithLocalizedMessage(Constants.LocalizedValueKeys.Email.EmptyEmailValidationMessage);
            return options;
        }

        public static IRuleBuilder<T, string> Username<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithLocalizedMessage(Constants.LocalizedValueKeys.Username.EmptyUsernameValidationMessage);
            return options;
        }

        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithLocalizedMessage(Constants.LocalizedValueKeys.Password.EmptyPasswordValidationMessage)
                .MinimumLength(6).WithLocalizedMessage(Constants.LocalizedValueKeys.Password.PasswordMinimumLengthValidationMessage)
                .Matches("[A-Z]").WithLocalizedMessage(Constants.LocalizedValueKeys.Password.PasswordShouldContainUppercasedWordValidationMessage)
                .Matches("[a-z]").WithLocalizedMessage(Constants.LocalizedValueKeys.Password.PasswordShouldContainLowercasedWordValidationMessage)
                .Matches("[0-9]").WithLocalizedMessage(Constants.LocalizedValueKeys.Password.PasswordShouldContainNumberValidationMessage);
            return options;
        }

        public static IRuleBuilder<T, string> Fullname<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithLocalizedMessage(Constants.LocalizedValueKeys.Fullname.EmptyFullnameValidationMessage)
                .MaximumLength(100).WithLocalizedMessage(Constants.LocalizedValueKeys.Fullname.NotValidFullnameValidationMessage);
            //.Must(IsValidName).WithMessage("Please enter valid Name!");
            return options;
        }

        #region Custom Rule Options

        private static IRuleBuilderOptions<T, string> WithLocalizedMessage<T>(this IRuleBuilderOptions<T, string> options, string key)
        {
            IStringLocalizer localizer = new JsonStringLocalizer();
            var localizedValue = localizer[key].Value;
            return options.Configure(x => x.CurrentValidator.Options.SetErrorMessage(localizedValue));
        }

        #endregion
    }
}