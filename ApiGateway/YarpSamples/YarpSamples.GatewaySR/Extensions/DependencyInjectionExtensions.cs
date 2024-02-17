using Microsoft.Extensions.DependencyInjection;
using Yarp.ReverseProxy.Configuration;

namespace YarpSamples.GatewaySR.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IReverseProxyBuilder LoadFromEureka(this IReverseProxyBuilder builder)
        {
            builder.Services.AddSingleton<EurekaProxyConfigProvider>();
            builder.Services.AddSingleton<IProxyConfigProvider>(c => c.GetRequiredService<EurekaProxyConfigProvider>());
            builder.Services.AddSingleton<IHostedService>(c => c.GetRequiredService<EurekaProxyConfigProvider>());
            return builder;
        }
    }
}
