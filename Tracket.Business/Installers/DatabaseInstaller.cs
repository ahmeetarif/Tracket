using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracket.Core.Business.Installer;
using Tracket.Data;

namespace Tracket.Business.Installers
{
    public class DatabaseInstaller : IBaseInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TracketDbContext>(config => config.UseSqlServer(configuration.GetConnectionString("Default")));
        }
    }
}