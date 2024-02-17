using Microsoft.Extensions.Primitives;
using Steeltoe.Discovery;
using Steeltoe.Discovery.Eureka;
using System.Security.Cryptography.Xml;
using Yarp.ReverseProxy.Configuration;

namespace YarpSamples.GatewaySR.Extensions
{
    public class EurekaProxyConfigProvider : BackgroundService, IProxyConfigProvider
    {
        private EurekaProxyConfig _config;
        private readonly DiscoveryClient _discoveryClient;
        private readonly List<RouteConfig> _routeConfigs;
        public IProxyConfig GetConfig() => _config;

        public EurekaProxyConfigProvider(IDiscoveryClient discoveryClient)
        {
            _discoveryClient = discoveryClient as DiscoveryClient;
            _routeConfigs = new List<RouteConfig>
            {
                new RouteConfig
                {
                    RouteId="FirstNameRoute",
                    ClusterId="FirstName",
                    Match= new RouteMatch
                    {
                         Path="f/{**catch-all}"
                    },
                    Transforms = new List<Dictionary<string, string>>
                    {
                        new Dictionary<string, string>{ { "PathRemovePrefix", "/f"} }
                    }
                },
                new RouteConfig
                {
                    RouteId="LastNameRoute",
                    ClusterId="LastName",
                    Match= new RouteMatch
                    {
                         Path="l/{**catch-all}"
                    },
                    Transforms = new List<Dictionary<string, string>>
                    {
                        new Dictionary<string, string>{ { "PathRemovePrefix", "/l"} }
                    }
                }
            };
            PopulateConfig();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                PopulateConfig();
                await Task.Delay(3000, stoppingToken);
            }
        }

        private void PopulateConfig()
        {
            var apps = _discoveryClient.Applications.GetRegisteredApplications();
            List<ClusterConfig> clusters = new List<ClusterConfig>();
            foreach (var app in apps)
            {
                var cluster = new ClusterConfig
                {
                    LoadBalancingPolicy="RoundRobin",
                    ClusterId = app.Name,
                    Destinations = app.Instances.Select(c =>
                    (
                        c.InstanceId,
                        new DestinationConfig()
                        {
                            Address = $"http://{c.HostName}:{c.Port}"
                        }
                    )).ToDictionary(d => d.InstanceId, d => d.Item2)
                };
                clusters.Add(cluster);
            }

            var temp = _config;
            _config = new EurekaProxyConfig(_routeConfigs, clusters);
            temp?.SignalChange();
        }
    }
    public class EurekaProxyConfig : IProxyConfig
    {
        private readonly CancellationTokenSource _cancellation = new CancellationTokenSource();
        public IReadOnlyList<RouteConfig> Routes { get; }

        public IReadOnlyList<ClusterConfig> Clusters { get; }

        //To know that the config has been changed.
        public IChangeToken ChangeToken { get; }

        public EurekaProxyConfig(IReadOnlyList<RouteConfig> routes, IReadOnlyList<ClusterConfig> clusters)
        {
            Routes = routes;
            Clusters = clusters;
            ChangeToken = new CancellationChangeToken(_cancellation.Token);
        }

        public void SignalChange()
        {
            _cancellation.Cancel();
        }
    }
}
