using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tracket.Business.Services.Abstract;
using Tracket.Business.Services.Concrete;
using Tracket.Core.Business.Installer;
using Tracket.Core.Data.UnitOfWork;
using Tracket.Data;

namespace Tracket.Business.Installers
{
    public class DependencyInstaller : IBaseInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Scopes

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IUnitOfWork<TracketDbContext>, UnitOfWork<TracketDbContext>>();

            #endregion
        }
    }
}