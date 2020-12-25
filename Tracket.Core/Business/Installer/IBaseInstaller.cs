using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Tracket.Core.Business.Installer
{
    public interface IBaseInstaller
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}