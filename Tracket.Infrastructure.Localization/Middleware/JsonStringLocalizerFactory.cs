using Microsoft.Extensions.Localization;
using System;
using Tracket.Infrastructure.Localization.Localizer;

namespace Tracket.Infrastructure.Localization.Middleware
{
    public class JsonStringLocalizerFactory : IStringLocalizerFactory
    {
        public IStringLocalizer Create(string baseName, string location)
        {
            return new JsonStringLocalizer();
        }

        public IStringLocalizer Create(Type resourceSource)
        {
            return new JsonStringLocalizer();
        }
    }
}