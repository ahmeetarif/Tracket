using Microsoft.AspNetCore.Builder;

namespace Tracket.Api.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tracket.Api v1"));
        }
    }
}