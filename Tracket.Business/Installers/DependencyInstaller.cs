using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracket.Core.Business.Installer;

namespace Tracket.Business.Installers
{
    public class DependencyInstaller : IBaseInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
        }
    }
}