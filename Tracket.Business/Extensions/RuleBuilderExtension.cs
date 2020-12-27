using FluentValidation;
using Microsoft.Extensions.Localization;
using Tracket.Infrastructure.Localization.Localizer;

namespace Tracket.Business.Extensions
{
    public static class RuleBuilderExtension
    {
        public static IRuleBuilder<T, string> Email<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithLocalizedMessage("EmptyEmail");
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