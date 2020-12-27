using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Tracket.Business.Extensions;
using Tracket.Infrastructure.Identity;
using Tracket.Infrastructure.Localization;

namespace Tracket.Api.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityInfrastructure(configuration);
            services.AddBusiness(configuration);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tracket.Api", Version = "v1" });
            });

            services.AddLocalizationInfrastructure();
        }
    }
}