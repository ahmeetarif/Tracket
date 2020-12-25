using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracket.Core.Business.Installer;
using Tracket.Infrastructure.Identity;

namespace Tracket.Business.Installers
{
    public class BaseInstaller : IBaseInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {

        }
    }
}