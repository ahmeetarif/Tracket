using FluentValidation;

namespace Tracket.Business.Extensions
{
    public static class RuleBuilderExtension
    {
        public static IRuleBuilder<T, string> Email<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage("Please enter your Email Address!");
            return options;
        }
    }
}