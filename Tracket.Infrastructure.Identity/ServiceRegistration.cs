using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracket.Data;
using Tracket.Entities.Entity;

namespace Tracket.Infrastructure.Identity
{
    public static class ServiceRegistration
    {
        public static void AddIdentityInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<TracketUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "._";
            })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<TracketDbContext>();
        }
    }
}