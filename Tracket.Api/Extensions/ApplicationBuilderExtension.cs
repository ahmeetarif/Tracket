using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Tracket.Api.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tracket.Api v1"));
        }

        public static void ConfigureLocalizationCultures(this IApplicationBuilder app)
        {
            IList<CultureInfo> supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("tr-TR")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
        }

        public static void ConfigureHealthChecks(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                ResponseWriter = async (c, r) =>
                {
                    c.Response.ContentType = "application/json";

                    var result = JsonConvert.SerializeObject(new
                    {
                        status = r.Status.ToString(),
                        Components = r.Entries.Select(x => new { key = x.Key, value = x.Value.Status.ToString() })
                    });

                    await c.Response.WriteAsync(result);
                }
            });
        }
    }
}