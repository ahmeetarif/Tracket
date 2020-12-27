using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Tracket.Core.Business.Installer;

namespace Tracket.Business.Installers
{
    public class BaseInstaller : IBaseInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .AddFluentValidation(config =>
                {
                    config.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });
        }
    }
}