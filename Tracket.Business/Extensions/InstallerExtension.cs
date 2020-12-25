using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;
using Tracket.Core.Business.Installer;

namespace Tracket.Business.Extensions
{
    public static class InstallerExtension
    {
        public static void AddBusiness(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = Assembly.GetExecutingAssembly().ExportedTypes.Where(x => typeof(IBaseInstaller).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface).Select(Activator.CreateInstance).Cast<IBaseInstaller>().ToList();

            installers.ForEach(x => x.InstallServices(services, configuration));
        }
    }
}