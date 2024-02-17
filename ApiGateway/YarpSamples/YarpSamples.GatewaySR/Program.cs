using Steeltoe.Discovery.Client;
using YarpSamples.GatewaySR.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDiscoveryClient();
builder.Services.AddReverseProxy()
    .LoadFromEureka();
    //.LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

app.MapReverseProxy();
app.Run();
