using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Reflection;
using Tracket.Business.Filters;
using Tracket.Core.Business.Installer;
using Tracket.Data;
using Tracket.Entities.Entity;
using Tracket.Infrastructure.Identity;

namespace Tracket.Business.Installers
{
    public class BaseInstaller : IBaseInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add<ExceptionFilter2>();
            })
                .AddFluentValidation(config =>
                {
                    config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

            services.AddIdentityInfrastructure<TracketUser, IdentityRole, TracketDbContext>(configuration);

            services.AddHealthChecks()
                .AddSqlServer(
                    configuration.GetConnectionString("Default"),
                    healthQuery: "Select 1;",
                    name: "Database Connection",
                    timeout: TimeSpan.FromSeconds(30),
                    tags: new[] { "db", "sql", "sqlServer" },
                    failureStatus: HealthStatus.Degraded
                );
        }
    }
}