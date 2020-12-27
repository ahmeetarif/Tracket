using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Tracket.Infrastructure.Localization.Localizer;
using Tracket.Infrastructure.Localization.Middleware;

namespace Tracket.Infrastructure.Localization
{
    public static class ServiceRegistration
    {
        public static void AddLocalizationInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
            services.AddSingleton<IStringLocalizer, JsonStringLocalizer>();
            services.AddLocalization(options => options.ResourcesPath = "Localize");
        }
    }
}