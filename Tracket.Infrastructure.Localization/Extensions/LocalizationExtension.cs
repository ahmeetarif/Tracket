using Microsoft.Extensions.Localization;

namespace Tracket.Infrastructure.Localization.Extensions
{
    public static class LocalizationExtension
    {
        public static string LocalizeMe(this IStringLocalizer localizer, string key)
        {
            return localizer.GetString(key);
        }
    }
}